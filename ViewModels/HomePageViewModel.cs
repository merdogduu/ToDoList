﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class HomePageViewModel
    {
        public List<ToDoes> ToDoes { get; set; }
    }
}