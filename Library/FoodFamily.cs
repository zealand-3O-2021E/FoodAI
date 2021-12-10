using System;
using System.Collections.Generic;

namespace Library
{


    public class RecognitionResult
    {
        public string name { get; set; }
        public double prob { get; set; }
    }


    public class ExtendedIngredient
    {
        public string original { get; set; }
    }

    public class Nutrient
    {
        public string name { get; set; }
        public double amount { get; set; }
        public string unit { get; set; }
    }

    public class Nutrition
    {
        public List<Nutrient> nutrients { get; set; }
    }

    public class Step
    {
        public int number { get; set; }
        public string step { get; set; }
    }

    public class AnalyzedInstruction
    {
        public List<Step> steps { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
    }

    public class Results
    {
        public List<Result> results { get; set; }
        public List<RecognitionResult> recognition_results { get; set; }
        public int imageId { get; set; }
    }

    public class Root
    {
        public List<ExtendedIngredient> extendedIngredients { get; set; }
        public Nutrition nutrition { get; set; }
        public List<AnalyzedInstruction> analyzedInstructions { get; set; }
    }
}

