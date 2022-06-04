using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SelectionAds.Controllers
{
    public class SelectionController : Controller
    {
        // GET: SelectionControl
        public ActionResult Index()
        {
            return View();
        }

        // GET: SelectionControl/Details/5
        public async Task<ActionResult> SelectAds(Guid guid)
        {
            return View();
        }

        // GET: SelectionControl/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SelectionControl/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
