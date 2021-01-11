using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrianglesCalculations.Models;
using static TrianglesCalculations.ControllersHandlers.TriangleControllerHandler;

namespace TrianglesCalculations.Controllers
{
    public class TriangleController : Controller
    {
        public IActionResult Welcome() =>
            Content("Welcome");
        /// <summary>
        /// Denys's tasks
        /// </summary>
        /// 1-3, 9-11
        public IActionResult Info(Triangle triangle) =>
            Content(InfoHandler(triangle));

        public IActionResult Perimeter(Triangle triangle) =>
            Content(PerimeterHandler(triangle).ToString());

        public IActionResult Area(Triangle triangle) =>
            Content(AreaHandler(triangle).ToString());

        public IActionResult GreatestByPerimeter(Triangle[] tr) =>
            Content(GreatestByPerimeterHandler(tr));

        public IActionResult GreatestByArea(Triangle[] tr) =>
            Content(GreatestByAreaHandler(tr));

        public IActionResult PairwiseNonSimilar(Triangle[] tr) =>
            Content(PairwiseNonSimilarHandler(tr));

        /// <summary>
        /// Oleg's tasks
        /// </summary>
        /// 4-8
        public IActionResult IsRightAngled(Triangle tr) =>
            Content(IsRightAngledHandler(tr).ToString());

        public IActionResult IsEquilateral(Triangle tr) =>
            Content(IsEquilateralHandler(tr).ToString());

        public IActionResult IsIsosceles(Triangle tr) =>
            Content(IsIsoscelesHandler(tr).ToString());

        public IActionResult AreCongruent(Triangle tr1, Triangle tr2) =>
            Content(AreCongruentHandler((tr1, tr2)).ToString());

        public IActionResult AreSimilar(Triangle tr1, Triangle tr2) =>
            Content(AreSimilarHandler((tr1, tr2)).ToString());
    }
}