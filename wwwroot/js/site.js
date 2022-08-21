// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const typed = select('.typed')
  if (typed)
  {
    let typed_strings =typed.getAttribute('data-typed-items')
    typed_strings = typed_strings.split(',')
    new typed('.typed', {
        strings: typed_strings,
        loop: true,
        typeSpeed:70,
        backSpeed: 40,
        backdelay: 2500
    });
  }
