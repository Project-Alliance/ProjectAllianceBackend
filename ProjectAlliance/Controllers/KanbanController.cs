
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAlliance.Data;
using ProjectAlliance.Models;

namespace ProjectAlliance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanbanController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public KanbanController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Kanban
        [Authorize]
        [HttpPost("AddBoardLane")]
        public IActionResult Create(int projectId,[FromBody] BoardLane boardLane)
        {
            if (boardLane == null||ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            boardLane.id = Guid.NewGuid().ToString();
            boardLane.projectId = projectId;
            _context.boardlane.Add(boardLane);
            _context.SaveChanges();
            return Ok(boardLane);
        }
        [Authorize]
        [HttpPost("AddBoardCard")]
        public IActionResult Create(string laneId,[FromBody] BoardCard boardCard)
        {
            if (boardCard == null || ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            boardCard.id = Guid.NewGuid().ToString();
            boardCard.lid = laneId;
            _context.boardCard.Add(boardCard);
            _context.SaveChanges();
            return Ok(boardCard);
        }
        [Authorize]
        [HttpGet("getBoardLane")]
        public IActionResult getBoardLane(int projectId)
        {
            var boardLane = _context.boardlane.Where(x => x.projectId == projectId).ToList();
            List<object> boardLanes = new List<object>();
            foreach (var item in boardLane)
            {
                var cards = _context.boardCard.Where(x => x.lid == item.id).ToList();
                boardLanes.Add(
                    new { 
                    item.id,
                    item.title,
                    item.label,
                    cards
                    });
            }
            return Ok(boardLanes);
        }
        [Authorize]
        [HttpDelete("deleteBoardLane")]
        public IActionResult deleteBoardLane(string lid)
        {
            var boardLane = _context.boardlane.Where(x => x.id == lid).FirstOrDefault();
            if (boardLane == null)
            {
                return NotFound();
            }
            var boardCards = _context.boardCard.Where(x => x.lid == lid).ToList();
            if(boardCards!=null){
                 _context.boardCard.RemoveRange(boardCards);
            }
            _context.boardlane.Remove(boardLane);
            _context.SaveChanges();
            return Ok(boardLane);
        }
        [Authorize]
        [HttpDelete("deleteBoardCard")]
        public IActionResult deleteBoardCard(string id)
        {
            var boardCard = _context.boardCard.Where(x => x.id == id).FirstOrDefault();
            if (boardCard == null)
            {
                return NotFound();
            }
            _context.boardCard.Remove(boardCard);
            _context.SaveChanges();
            return Ok(boardCard);
        }
        [Authorize]
        [HttpPut("updateBoardLane")]
        public IActionResult updateBoardLane(string lid,string title,string label)
        {
            var boardLane = _context.boardlane.Where(x => x.id == lid).FirstOrDefault();
            if (boardLane == null)
            {
                return NotFound();
            }
            boardLane.title = title;
            boardLane.label = label;
            _context.SaveChanges();
            return Ok(boardLane);
        }
        [Authorize]
        [HttpPut("updateBoardCard")]
        public IActionResult updateBoardCard(string id,string title,string description,string label,string laneId)
        {
            var boardCard = _context.boardCard.Where(x => x.id == id).FirstOrDefault();
            if (boardCard == null)
            {
                return NotFound();
            }
            boardCard.lid = laneId!="null"?laneId:boardCard.lid;
            boardCard.label = label!="null"?label:boardCard.label;
            boardCard.title = title!="null"?title:boardCard.title;
            boardCard.description = description!="null"?description:boardCard.description;
            _context.SaveChanges();
            return Ok(boardCard);
        }
    }
    }