﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bageriet.Controllers
{

    [Authorize]
    public class CommentaryController : Controller
    {
        private readonly ICommentary _CommentaryRepository;
        private Commentary _Commentary;

        public CommentaryController(ICommentary CommentaryRepository)
        {
            _CommentaryRepository = CommentaryRepository;
        }

       
        public IActionResult CommentaryD(int id)
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult CommentaryD(Commentary newCommentary)
        {


            _Commentary = newCommentary;

            // Hvordan får jeg mit pieId med fra order formen?          

            if (_Commentary.CommentMessage == "")
            {
                ModelState.AddModelError("", "Please insert Your Review is empty");
            }

            if (ModelState.IsValid)
            {
                _CommentaryRepository.CreateCommentAndAddToDatabase(newCommentary);
                return RedirectToAction("ReviewComplete");
            }

            return View(newCommentary);
        }

        public IActionResult ReviewComplete()
        {
            ViewBag.ReviewCompleteMessage = "Thank you";
            return View();
        }
    }
}
