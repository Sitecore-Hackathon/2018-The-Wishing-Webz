(function($) {
  "use strict"; // Start of use strict

  // Smooth scrolling using jQuery easing
  $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      if (target.length) {
        $('html, body').animate({
          scrollTop: (target.offset().top - 70)
        }, 1000, "easeInOutExpo");
        return false;
      }
    }
  });

  // Scroll to top button appear
  $(document).scroll(function() {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
      $('.scroll-to-top').fadeIn();
    } else {
      $('.scroll-to-top').fadeOut();
    }
  });

  // Closes responsive menu when a scroll trigger link is clicked
  $('.js-scroll-trigger').click(function() {
    $('.navbar-collapse').collapse('hide');
  });

  // Activate scrollspy to add active class to navbar items on scroll
  $('body').scrollspy({
    target: '#mainNav',
    offset: 80
  });

  // Collapse Navbar
  var navbarCollapse = function() {
    if ($("#mainNav").offset().top > 100) {
      $("#mainNav").addClass("navbar-shrink");
    } else {
      $("#mainNav").removeClass("navbar-shrink");
    }
  };
  // Collapse now if page is not at top
  navbarCollapse();
  // Collapse the navbar when page is scrolled
  $(window).scroll(navbarCollapse);

  // Modal popup$(function () {
  $('.modal-item').magnificPopup({
    type: 'inline',
    preloader: false,
    focus: '#username',
    modal: true
  });
  $(document).on('click', '.portfolio-modal-dismiss', function(e) {
    e.preventDefault();
    $.magnificPopup.close();
  });

  // Floating label headings for the contact form
  $(function() {
    $("body").on("input propertychange", ".floating-label-form-group", function(e) {
      $(this).toggleClass("floating-label-form-group-with-value", !!$(e.target).val());
    }).on("focus", ".floating-label-form-group", function() {
      $(this).addClass("floating-label-form-group-with-focus");
    }).on("blur", ".floating-label-form-group", function() {
      $(this).removeClass("floating-label-form-group-with-focus");
        });

    // Load Consent
    $(document).ready(function () {
        var consentResponse = getConsent();
        console.log(consentResponse);
        if (consentResponse.consentAnswered) {
            // Nothing
        } else {
            setTimeout(function () {
                if ($('#consent-modal-1').length) {
                    $.magnificPopup.open({
                        items: {
                            src: '#consent-modal-1'
                        },
                        type: 'inline'
                    });
                }
            }, 1000);
        }
    });
    // Submit Consent
    $('#submitConsent').click(function (ev) {
        var cuform = $('#frmConsent');
        console.log(cuform);
        $.ajax({
            url: cuform.attr('action'),
            type: 'POST',
            data: cuform.serialize(),
            success: function (response) {
                if (!response.error) {
                    // TO DO: Do stuff with answers
                    console.log(response);
                    var magnificPopup = $.magnificPopup.instance; 
                    magnificPopup.close(); 
                } else {
                    console.log(response.errorMsg)
                }
            },
            error: function (ex) {
                console.log(ex);
            }
        });
        ev.preventDefault();
    });

    // Submit Account
    $('#submitAccount').click(function (ev) {
        var cuform = $('#frmAccount');
        console.log(cuform);
        $.ajax({
            url: cuform.attr('action'),
            type: 'POST',
            data: cuform.serialize(),
            success: function (response) {
                if (!response.error) {
                    // TO DO: Do stuff with answers
                    console.log(response);
                    var magnificPopup = $.magnificPopup.instance;
                    magnificPopup.close();
                } else {
                    console.log(response.errorMsg)
                }
            },
            error: function (ex) {
                console.log(ex);
            }
        });
        ev.preventDefault();
    });


  });
  function getConsent() {
      $.ajax({
          url: '/api/sitecore/Content/GetConsent',
          type: 'GET',
          success: function (response) {
              if (!response.error) {
                  return response;
              } else {
                  console.log(response.errorMsg)
              }
          },
          error: function (ex) {
              console.log(ex);
          }
      });
  }

})(jQuery); // End of use strict
