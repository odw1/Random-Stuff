using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapperProfiles.Domain.Contracts;
using AutoMapperProfiles.Framework;
using AutoMapperProfiles.Web.Models;

namespace AutoMapperProfiles.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonTasks _personTasks;
        private readonly IMapper _mapper;

        public PersonController(IPersonTasks personTasks, IMapper mapper)
        {
            _personTasks = personTasks;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var person = _personTasks.Get(25);
            var viewModel = _mapper.Map<PersonViewModel>(person);

            return View(viewModel);
        }

    }
}
