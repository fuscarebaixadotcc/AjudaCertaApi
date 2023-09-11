using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Data;
using Microsoft.AspNetCore.Mvc;

namespace AjudaCertaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoacoesController : ControllerBase
    {
        private readonly DataContext _context;
        public DoacoesController(DataContext context)
        {
            _context = context;
        }

        

    }
}