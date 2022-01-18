﻿using System;
using System.Collections.Generic;
using System.IO;
using FoodApi.Controllers;
using Library;
using Newtonsoft.Json;
using RestSharp;
using static FoodApi.Controllers.FoodController;

namespace FoodApi.Manager
{
    public class FoodManager
    {

        public Results GetFood(FileUploadAPI objFile)
        {
            var client = new RestClient("https://api.logmeal.es/v2/recognition/complete");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer f028c1782bd0027941df4945cb4003f0ee05ae22");  
            request.AddFile("image", GetBytes(objFile), "test.jpeg");
            IRestResponse response = client.Execute(request);
            Results myDeserializedClass = JsonConvert.DeserializeObject<Results>(response.Content);
            return myDeserializedClass;
        }

        public History GetCal(int id)
        {
            var client = new RestClient("https://api.logmeal.es/v2/recipe/nutritionalInfo");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer f028c1782bd0027941df4945cb4003f0ee05ae22");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { imageId = id});
            IRestResponse response = client.Execute(request);
            History myDeserializedClass = JsonConvert.DeserializeObject<History>(response.Content);
            return myDeserializedClass;
        }

        public Results GetOp(string name)
        {
            var client = new RestClient("https://api.spoonacular.com/recipes/complexSearch?" +
                "apiKey=9ef9cfb98ac34af3a343d005379963c0");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddParameter("query", name);
            IRestResponse response = client.Execute(request);
            Results myDeserializedClass = JsonConvert.DeserializeObject<Results>(response.Content);
            return myDeserializedClass;
        }

        public Root GetRecipe(int id)
        {
            var client = new RestClient("https://api.spoonacular.com/recipes/" +
                id +
                "/information?" +
                "apiKey=9ef9cfb98ac34af3a343d005379963c0" +
                "&includeNutrition=true");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response.Content);
            return myDeserializedClass;
        }

        public static byte[] GetBytes(FileUploadAPI s)
        {
            using (var ms = new MemoryStream())
            {
                s.files.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}

