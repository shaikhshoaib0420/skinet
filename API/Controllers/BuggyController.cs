using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class BuggyController: BaseApiController {


    [HttpGet("not-found")]
    public ActionResult GetNotFoundError() {
        return NotFound();
    }

    [HttpGet("bad-request")]
    public ActionResult GetBadRequestError() {
        ModelState.AddModelError("title", "This is bad request!");
        ModelState.AddModelError("status", "400");
        return BadRequest(ModelState);
    }

    [HttpGet("unauthorized")]
    public ActionResult GetUnauthorizedError() {
        return Unauthorized();
    }

    [HttpGet("server-error")]
    public ActionResult GetServerError() {
        throw new Exception("This is a server error.");
    }

    [HttpGet("validation-error")]
    public ActionResult GetValidationError() {
        ModelState.AddModelError("1", "This is first validation error!");
        ModelState.AddModelError("2", "This is second validation error!");

        return ValidationProblem();
    }
}
