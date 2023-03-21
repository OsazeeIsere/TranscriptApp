using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranscriptApp.Data;
using TranscriptApp.Models;

namespace TranscriptApp.Controllers
{
    public class FinalApprovedResultsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FinalApprovedResultsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment=hostingEnvironment;
        }

        // GET: FinalApprovedResults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FinalApprovedResults.Include(f => f.Courses).Include(f => f.Departments).Include(f => f.Faculties).Include(f => f.Sessions);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FinalApprovedResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FinalApprovedResults == null)
            {
                return NotFound();
            }

            var finalApprovedResult = await _context.FinalApprovedResults
                .Include(f => f.Courses)
                .Include(f => f.Departments)
                .Include(f => f.Faculties)
                .Include(f => f.Sessions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finalApprovedResult == null)
            {
                return NotFound();
            }

            return View(finalApprovedResult);
        }

        // GET: FinalApprovedResults/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Name");
            return View();
        }

        // POST: FinalApprovedResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile uploadResult, FinalApprovedResult finalApprovedResult)
        {
            if (uploadResult != null && uploadResult.Length > 0)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uploadResult.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadResult.CopyTo(fileStream);
                }

                // Do something with the file path

                // read the PDF file into a byte array
                //  var path = Path.GetPathRoot(uploadResult.FileName);
                //var extension = Path.GetExtension(passport.FileName);
                //var webRootPath = _hostingEnvironment.WebRootPath;
                //fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;

                byte[] pdfBytes = System.IO.File.ReadAllBytes(filePath);

                // create a new PdfDocument object
                var finalUpload = new FinalApprovedResult()
                {//Id,CourseId,ProgramDuratin,ProgramType,FileUpload,CreatedAt,CreatedBy"
                    SessionId = finalApprovedResult.SessionId,
                    DepartmentId = finalApprovedResult.DepartmentId,
                    FacultyId = finalApprovedResult.FacultyId,
                    CourseId = finalApprovedResult.CourseId,
                    ProgramDuratin = finalApprovedResult.ProgramDuratin,
                    ProgramType = finalApprovedResult.ProgramType,
                    FileUpload = pdfBytes

                };
                //{
                //    Name = "My PDF Document",
                //    Content = pdfBytes
                //};
                _context.Add(finalUpload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", finalApprovedResult.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", finalApprovedResult.DepartmentId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", finalApprovedResult.FacultyId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", finalApprovedResult.SessionId);
            return View(finalApprovedResult);
        }

        // GET: FinalApprovedResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FinalApprovedResults == null)
            {
                return NotFound();
            }

            var finalApprovedResult = await _context.FinalApprovedResults.FindAsync(id);
            if (finalApprovedResult == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", finalApprovedResult.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", finalApprovedResult.DepartmentId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", finalApprovedResult.FacultyId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", finalApprovedResult.SessionId);
            return View(finalApprovedResult);
        }

        // POST: FinalApprovedResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SessionId,DepartmentId,FacultyId,CourseId,ProgramDuratin,ProgramType,FileUpload,CreatedAt,CreatedBy")] FinalApprovedResult finalApprovedResult)
        {
            if (id != finalApprovedResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalApprovedResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalApprovedResultExists(finalApprovedResult.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", finalApprovedResult.CourseId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", finalApprovedResult.DepartmentId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", finalApprovedResult.FacultyId);
            ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Id", finalApprovedResult.SessionId);
            return View(finalApprovedResult);
        }

        // GET: FinalApprovedResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FinalApprovedResults == null)
            {
                return NotFound();
            }

            var finalApprovedResult = await _context.FinalApprovedResults
                .Include(f => f.Courses)
                .Include(f => f.Departments)
                .Include(f => f.Faculties)
                .Include(f => f.Sessions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finalApprovedResult == null)
            {
                return NotFound();
            }

            return View(finalApprovedResult);
        }

        // POST: FinalApprovedResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FinalApprovedResults == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FinalApprovedResults'  is null.");
            }
            var finalApprovedResult = await _context.FinalApprovedResults.FindAsync(id);
            if (finalApprovedResult != null)
            {
                _context.FinalApprovedResults.Remove(finalApprovedResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalApprovedResultExists(int id)
        {
          return (_context.FinalApprovedResults?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
