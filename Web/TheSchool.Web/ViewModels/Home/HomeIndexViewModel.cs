﻿namespace TheSchool.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using TheSchool.Web.ViewModels.Students;

    public class HomeIndexViewModel
    {
        public ICollection<StudentViewModel> Students { get; set; }
    }
}