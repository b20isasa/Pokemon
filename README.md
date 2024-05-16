# lychee


README.md with instructions on how to get the project running, how to
view the documentation, and how to run the tests

För att köra denna, bör vissa bibliotek erhållas.
using lychee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;


För att starta upp projektet skall en grön start-knapp klickas, eller använda kortkommandot F5. 
Fyll sedan i formuläret med antingen namn på pokemon eller ID:et.

För att kunna se dokumentationen i Swagger så addera detta efter https://localhost(dinport)/swagger/v1/swagger.json


--------------------------------------------------------------------------------------------------------------


Denna uppgift utfördes den 16/5. 

Förbättringsförslag: 
1) Jag gjorde try-catch, vilket i detta fall var onödigt med tanke på att en if-sats fångar upp inmatningsfel. 
2) jag kunde även utformat mina if/else mer kompakt samt förkortatt genom exempelvis:
[HttpGet("{id}")]
[ProducesResponseType<XXX>(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult GetById_IActionResult(int id)
{
    var product = _productContext.XXX.Find(id);
    return product == null ? NotFound() : Ok(product);
}

3) Inget hänsyn togs till design och UI/UX.
