﻿using BowlingAPI.Data;
using BowlingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        public BowlerController(IBowlerRepository temp) { 
            _bowlerRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            var bowlerData = _bowlerRepository.Bowlers
                .Join(
                    _bowlerRepository.Teams,
                    bowler => bowler.TeamId,
                    team => team.TeamId,
                    (bowler, team) => new Bowler
                    {
                        BowlerId = bowler.BowlerId,
                        BowlerLastName = bowler.BowlerLastName,
                        BowlerFirstName = bowler.BowlerFirstName,
                        BowlerMiddleInit = bowler.BowlerMiddleInit,
                        BowlerAddress = bowler.BowlerAddress,
                        BowlerCity = bowler.BowlerCity,
                        BowlerState = bowler.BowlerState,
                        BowlerZip = bowler.BowlerZip,
                        BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                        TeamId = bowler.TeamId,
                        Team = new Team
                        {
                            TeamId = team.TeamId,
                            TeamName = team.TeamName,
                        }
                    })
                .Where(x => x.Team.TeamName == "Marlins" || x.Team.TeamName == "Sharks")
                .ToArray();

            return bowlerData;
        }

    }
}
