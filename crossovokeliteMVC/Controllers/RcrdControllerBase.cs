﻿using crossovokeliteMVC.Data;
using crossovokeliteMVC.Models;
using crossovokeliteMVC.Services;
using crossovokeliteMVC.Services.crossovokeliteMVC.Services;
using System.Web.Mvc;

namespace crossovokeliteMVC.Controllers
{
    public class RcrdControllerBase : Controller
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IRcrdService Rcrds { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }

        public RcrdControllerBase()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}