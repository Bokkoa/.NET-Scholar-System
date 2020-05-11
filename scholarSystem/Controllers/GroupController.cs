using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scholarSystem.DAL;

namespace scholarSystem.Controllers
{
    public class GroupController : Controller
    {
        private readonly ScholarSystemContext _context;

        public GroupController(ScholarSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //Method syntax
            var allGroups = _context.Groups.ToList();
            return View(allGroups);
        }
    }
}