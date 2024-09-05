using Microsoft.AspNetCore.Mvc;

namespace DynamicPricing.HelloWorld;

[ApiController]
[Route("[controller]")]
public class HelloWorld : ControllerBase{

     [HttpGet("helloWorld")]
     public String helloWorld(){
        return "Hello Guies ";
     }

}