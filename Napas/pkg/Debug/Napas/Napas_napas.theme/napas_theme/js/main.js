
(function ($) {
    $(document).on('ready', function () {

        "use strict";


        $('#menu').metisMenu({
            toggle: false // disable the auto collapse. Default: true.
        });
$(".home-slider .bxslider li").click(function(){
   var url = $(this).attr("data-url");
   if( typeof url !== 'undefined'){
        window.location.href = url;
   }
});
        $(".search .search-form").click(function(){
                    $(".form").fadeToggle(600);
                    return false;
        });
        $('.bxslider').bxSlider({
//             auto: true,
            mode: "fade",
            default: 10000,
//            autoControls: true
        });


        $('.gt-caption h3').click(function () {

            var parent = $(this).parents(".gt-caption");

            // alert($(parent).html());

            if ($(parent).next().is(":visible") == true && $(parent).next().hasClass("gt-content")) {
                $(parent).removeClass("active");
                $(parent).next().hide();
            }
            else if ($(parent).next().is(":visible") == false && $(parent).next().hasClass("gt-content")) {
                $(parent).addClass("active");
                $(parent).next().show();
            }

        })

        /**Review slider**/
        $('.owl-service').owlCarousel({
            loop: true,
            nav: true,
            mouseDrag: false,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            nav: true,
            responsive: {
                0: {
                    items: 1
                },
                350: {
                    items: 1
                },
                480: {
                    items: 2
                },
                768: {
                    items: 3
                },
                991: {
                    items: 4
                },

            }


        });

        $('.owl-bank').owlCarousel({
            loop: false,
            nav: true,
            mouseDrag: false,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            nav: true,
            items: 1,



        });

        $('.owl-bank-logo').owlCarousel({
            loop: true,
            nav: true,
            mouseDrag: false,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            nav: true,
            responsive: {
                0: {
                    items: 2
                },
                350: {
                    items: 2
                },
                480: {
                    items: 2
                },
                768: {
                    items: 3
                },
                991: {
                    items: 4
                },
                1000: {
                    items: 5
                }
            }


        });


        /**Preload**/
        $('#page-loader').delay(800).fadeOut(600, function () {
            $('body').fadeIn();
        });

        /**Menu Mobile**/
        $('.menu-icon ul .favicon a').on('click', function () {
            if ($('.menu-res ').is(":visible")) {

                $('.menu-res').slideUp();
            }
            else
            {
                $('.menu-res').slideDown();
            }
          return false;
        });
        $('.menu-res li.menu-item-has-children').on('click', function () {

            var submenu = $(this).find("ul");
            if ($(submenu).is(":visible")) {
                $(submenu).slideUp();
                $(this).removeClass("open-submenu-active");
            }
            else {
                $(submenu).slideDown();
                $(this).addClass("open-submenu-active");
            }
        });
 $(".menu-res li.menu-item-has-children > a").addClass("is-active");
            $(".menu-res li.menu-item-has-children .sub-menu li a").removeClass("is-active");
            $(".menu-res li.menu-item-has-children a.is-active").click(function () {
                $(this).attr("href", "javascript:void();");
//                $(this).parent().find(".sub-menu").fadeToggle();
            });
//        $('.menu-res li.menu-item-has-children > a').on('click', function () {
//            return false;
//        });
//        back top top
        $(".backtotop a").click(function(){
                  $('html,body').animate({
                      scrollTop: 0
                  }, 800);
        });
         var w_screen = $(window).width();                    
                        $(window).scroll(function () {
                            var y = $(window).scrollTop();
                            if (y > 400) {
                                $(".backtotop").show();
                            } else {
                                $(".backtotop").hide();
                            }
                        });
                    
    });
})(jQuery);