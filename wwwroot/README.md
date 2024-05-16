## Table of Contents


README.md with instructions on how to get the project running, how to
view the documentation, and how to run the tests

F�r att k�ra denna, b�r vissa bibliotek erh�llas.
using System.Net;
using System.Net.Http.Headers;
using lychee.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

F�r att starta upp projektet skall en gr�n start-knapp klickas, eller anv�nda kortkommandot F5. 
Fyll sedan i formul�ret med antingen namn p� pokemon eller ID:et.

--------------------------------------------------------------------------------------------------------------


Denna uppgift utf�rdes den 16/5. 

F�rb�ttringsf�rslag: 
1) Jag gjorde try-catch, vilket i detta fall var on�digt med tanke p� att en if-sats f�ngar upp inmatningsfel. 
2) jag kunde �ven utformat mina if/else mer kompakt samt f�rkortatt genom exempelvis:
[HttpGet("{id}")]
[ProducesResponseType<XXX>(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult GetById_IActionResult(int id)
{
    var product = _productContext.XXX.Find(id);
    return product == null ? NotFound() : Ok(product);
}

3) Inget h�nsyn togs till design och UI/UX.
