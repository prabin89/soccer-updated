﻿using SoccerUpdated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoccerUpdated.Controllers.API
{
    public class LeagueController : ApiController
    {
        private ApplicationDbContext _context;

        public LeagueController()
        {
            _context = new ApplicationDbContext();
        }

   
        public IHttpActionResult GetLeague()
        {
            var leagueQuery = _context.Leagues.ToList();

            return Ok(leagueQuery);
        }

        //get individual list
        public League GetLeague(int id)
        {
            var league = _context.Leagues.SingleOrDefault(l => l.Id == id);

            if (league == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return league;
        }

        //Add league
        [HttpPost]
        public League CreateLeague(League league)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Leagues.Add(league);
            _context.SaveChanges();

            return league;
        } 
    }
}
