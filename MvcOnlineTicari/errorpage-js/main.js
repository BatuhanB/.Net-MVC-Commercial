"use strict";

function pageResize () {
	// #page top & bottom paddings 30*2=60
	var page_padding = 60;
	// .page-cont-wrap top & bottom paddings 70*2=140
	var cont_padding = 140;
	if ($(window).width() <= 533) { // 550
		page_padding = 30;
	}
	var window_ht = $(window).height();
	var header_ht = $('.header').outerHeight();
	var lh = window_ht - header_ht - page_padding - cont_padding;
	$('.page-cont-wrap').css('line-height', lh + 'px')
}

function equilize_height (elements, cols, el_class) {
	var max_height = 0;
	$(elements).outerHeight('auto');
	$(elements).each(function (i) {
		var $el_index = $(this).index();
		var $col_elements = $(this);
		max_height = $(this).outerHeight();
		if (i % cols == 0) {
			for (var j = 1; j < cols; j++) {
				if ($(elements).eq($el_index + j).hasClass(el_class)) {
					max_height = Math.max(max_height, $(elements).eq($el_index + j).outerHeight());
					$col_elements = $col_elements.add($(elements).eq($el_index + j));
				}
			}
			$col_elements.outerHeight(max_height);
		}
	});
	return false;
}

$(document).ready(function () {

	// Full Height - Pages
	if ($('#page').length > 0) {
		$(window).resize(function () {
			pageResize();  
		});
		pageResize();
	}

});


$(window).load(function () {


	// Header Search - Toggle Button
	$('.header-search').on('click', '#header-search-btn', function () {
		if ($(this).hasClass('opened')) {
			$(this).removeClass('opened');
		} else {
			$(this).addClass('opened');
		}
		return false;
	});
	$('body').on('click', function() {
		if ($('#header-search-btn').length > 0 && $('#header-search-btn').hasClass('opened')) {
			$('#header-search-btn').removeClass('opened');
		}
	});
	$('.header-search').on('click', '#header-search', function(event){
	    event.stopPropagation();
	});


	// Top Menu - Toggle Button
	$('.header').on('click', '#mainmenu-btn', function () {
		if ($(this).hasClass('opened')) {
			$(this).removeClass('opened');
			$('#mainmenu-bg').fadeOut();
			$('body').removeClass('menu-opened');
		} else {
			var window_height = $(window).height();
			var items_count = $('#mainmenu > ul > li').length;
			var items_height = Math.max((window_height-200)/items_count, 45);
			var items_height = Math.min(items_height, 85);

			$(this).addClass('opened');

			$('body').addClass('menu-opened');

			$('#mainmenu > ul > li > a').each(function () {
				var item_height = $(this).height();
				var item_margin = items_height - item_height;
				$(this).css('padding-top', Math.round(item_margin/2));
				$(this).css('padding-bottom', Math.round(item_margin/2));
			});

			$('#mainmenu-bg').fadeIn();
		}
		return false;
	});
	$('body').on('click', '#mainmenu-bg', function () {
		$('#mainmenu-btn').removeClass('opened');
		$('body').removeClass('menu-opened');
		$('#mainmenu-bg').fadeOut();
		return false;
	});


	// Top Menu Links - Equilize Height
	if ($(window).width() > 751) { // 768
		$('#mainmenu > ul > li.mainmenu-parent')
		.on( "mouseenter", function() {
			var window_height = $(window).height();
			var sub_items_count = $(this).find('> ul > li').length;
			var sub_items_height = Math.max((window_height-175)/sub_items_count, 40);
			sub_items_height = Math.min(sub_items_height, 85);

			$(this).find('> ul').fadeIn(200);

			$(this).find('> ul > li').each(function () {
				var item_height = $(this).height();
				var item_margin = sub_items_height - item_height;
				$(this).css('margin-bottom', Math.round(item_margin));
			});
		})
		.on( "mouseleave", function() {
			$(this).find('> ul').fadeOut(200);
		});
	}
	$(window).resize(function () {
		if ($(window).width() > 751) { // 768
			$('#mainmenu > ul > li.mainmenu-parent')
			.on( "mouseenter", function() {
				var window_height = $(window).height();
				var sub_items_count = $(this).find('> ul > li').length;
				var sub_items_height = Math.max((window_height-175)/sub_items_count, 40);
				sub_items_height = Math.min(sub_items_height, 85);
			
				$(this).find('> ul > li').each(function () {
					var item_height = $(this).height();
					var item_margin = sub_items_height - item_height;
					$(this).css('margin-bottom', Math.round(item_margin));
				});

				$(this).find('> ul').fadeIn(200);
			})
			.on( "mouseleave", function() {
				$(this).find('> ul').fadeOut(200);
			});
		} else {
			$('#mainmenu > ul > li.mainmenu-parent').off("mouseenter");
			$('#mainmenu > ul > li.mainmenu-parent').off("mouseleave");
		}
	});
	$('#mainmenu > ul li.mainmenu-parent > a > .fa').on('click', function () {
		if ($(this).parent().parent().hasClass('opened')) {
			$(this).parent().parent().removeClass('opened');
			$(this).parent().next('ul').slideUp();
		} else {
			$(this).parent().next('ul').slideDown();
			$(this).parent().parent().addClass('opened');
		}
		return false;
	});


	// Homepage Slider
	if ($('#front-slider').length > 0) {
		$('#front-slider').fractionSlider({
			'fullWidth': 			true,
			'controls': 			true, 
			'pager': 				false,
			'responsive': 			true,
			'pauseOnHover': 		false,
			'dimensions': 			"1170,750",
			'startCallback': function(el, currentSlide, lastSlide, step ){
				$('.topslider .slider .prev').text('Prev').appendTo('.topslider');
				$('.topslider .slider .next').text('Next').appendTo('.topslider');

				$('.topslider .responisve-container').css('height', 'auto');
			},
			'startNextSlideCallback': function(el, currentSlide, lastSlide, step ){
			  $('.topslider').css('background', $('.topslider .slider .slide').eq(currentSlide).attr('data-bg'));
			}
		});
	}


	// Instagram Photos (Frontpage) - Masonry Grid
	if ($('#instagram-list').length > 0) {
		$('#instagram-list').masonry({
			columnWidth: '.instagram-sizer',
			itemSelector: '.instagram-item',
			percentPosition: true,
		});
	}


	// About Us - Masonry Grid
	if ($('#about-list').length > 0) {
		$('#about-list').masonry({
			columnWidth: '.about-i-sizer',
			itemSelector: '.about-i',
			percentPosition: true,
		});
	}


	// Fancybox for images
	$('.modal-img').fancybox({
		padding: 0,
		margin: [60, 50, 20, 50],
		helpers: {
			overlay: {
				locked: false
			},
			thumbs: {
				width: 60,
				height: 60
			}
		},
		tpl: {
			closeBtn: '<a title="Close" class="fancybox-item fancybox-close modal-close" href="javascript:;"></a>',
			prev: '<a title="Previous" class="fancybox-nav fancybox-prev modal-prev" href="javascript:;"><span></span></a>',
			next: '<a title="Next" class="fancybox-nav fancybox-next modal-next" href="javascript:;"><span></span></a>',
		}
	});


	// Modal Window Videos
    $(".about-video").on("click", ".modal-img", function() {
        $.fancybox({
            'padding'       : 0,
			'margin': [60, 20, 20, 20],
            'autoScale'     : false,
            'transitionIn'  : 'none',
            'transitionOut' : 'none',
            'href'          : this.href.replace(new RegExp("watch\\?v=", "i"), 'v/'),
            'type'          : 'swf',
            'swf'           : {
            'wmode'             : 'transparent',
            'allowfullscreen'   : 'true'
            },
            tpl: {
            	closeBtn: '<a title="Close" class="fancybox-item fancybox-close modal-close" href="javascript:;"></a>',
            	prev: '<a title="Previous" class="fancybox-nav fancybox-prev modal-prev" href="javascript:;"><span></span></a>',
            	next: '<a title="Next" class="fancybox-nav fancybox-next modal-next" href="javascript:;"><span></span></a>',
            }
        });
        return false;
    });


	// Homepage Posts - Equilize Height
	if ($('.post-front-list').length > 0) {

		if ($(window).width() > 1583) {
			equilize_height('.post-front-list .post-front', 4, 'post-front');
		} else if ($(window).width() > 975) {
			equilize_height('.post-front-list .post-front', 3, 'post-front');
		} else if ($(window).width() > 533) {
			equilize_height('.post-front-list .post-front', 2, 'post-front');
		}
		$(window).resize(function () {
			if ($(window).width() > 1583) { // 1220
				equilize_height('.post-front-list .post-front', 4, 'post-front');
			} else if ($(window).width() > 975) { // 768
				equilize_height('.post-front-list .post-front', 3, 'post-front');
			} else if ($(window).width() > 533) { // 550
				equilize_height('.post-front-list .post-front', 2, 'post-front');
			} else {
				$('.post-front-list .post-front').outerHeight('auto');
			}
		});

	}


	// Related Posts - Equilize Height
	if ($('.post-related-list').length > 0) {

		if ($(window).width() > 1203) {
			equilize_height('.post-related-list .post-related', 4, 'post-related');
		} else if ($(window).width() > 751) {
			equilize_height('.post-related-list .post-related', 3, 'post-related');
		} else if ($(window).width() > 533) {
			equilize_height('.post-related-list .post-related', 2, 'post-related');
		}
		$(window).resize(function () {
			if ($(window).width() > 1203) { // 1220
				equilize_height('.post-related-list .post-related', 4, 'post-related');
			} else if ($(window).width() > 751) { // 768
				equilize_height('.post-related-list .post-related', 3, 'post-related');
			} else if ($(window).width() > 533) { // 550
				equilize_height('.post-related-list .post-related', 2, 'post-related');
			} else {
				$('.post-related-list .post-related').outerHeight('auto');
			}
		});

	}


	// Blog Posts Slider
	if ($('.blog-slider').length > 0) {
		$('.blog-slider').flexslider({
		    animation: "fade",
		    animationSpeed: 500,
		    slideshow: false,
		    animationLoop: false,
		    directionNav: false,
		    smoothHeight: false,
			controlNav: true,
		});
	}


	// Single Post Slider
	if ($('.post-slider').length > 0) {
		$('.post-slider').flexslider({
		    animation: "fade",
		    animationSpeed: 500,
		    slideshow: false,
		    animationLoop: false,
		    directionNav: false,
		    smoothHeight: true,
			controlNav: true,
		});
	}


	// Animated ScrollTo
	$('a[data-goto^="#"]').on("click", function(){
		var target = $(this).attr('data-goto');
		$('html, body').animate({scrollTop: ($(target).offset().top - 30)}, 800);
		return false;
	});


	// Forms Validation
	var filterEmail  = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,6})+$/;
	$('.form-validate').submit(function () {
		var errors = 0;
		$(this).find('[data-required="text"]').each(function () {
            if ($(this).attr('data-required-email') == 'email'){
                if (!filterEmail.test($(this).val())) {
                    $(this).addClass("redborder");
                    errors++;
                }
                else {
                    $(this).removeClass("redborder");
                }
                return;
            }
			if ($(this).val() == '') {
				$(this).addClass('redborder');
				errors++;
			} else {
				$(this).removeClass('redborder');
			}
		});
		if (errors === 0) {
			var form1 = $(this);
			$.ajax({
				type: "POST",
				url: 'php/email.php',
				data: $(this).serialize(),
				success: function(data) {
					form1.append('<p class="form-result">Thank you!</p>');
		            $("form").trigger('reset');
				}
			});
		}
		return false;
	});
	$('.form-validate').find('[data-required="text"]').blur(function () {
        if ($(this).attr('data-required-email') == 'email' && ($(this).hasClass("redborder"))) {
            if (filterEmail.test($(this).val()))
                $(this).removeClass("redborder");
            return;
        }
		if ($(this).val() != "" && ($(this).hasClass("redborder")))
            $(this).removeClass("redborder");
	});


	// Homepage Projects Categories - Fixed Block
	if ($('#project-front-sections').length > 0) {
		$(window).scroll(function() {
			if ($(window).width() > 1123) { // 1140
				if ($('#project-front-sections').offset().top > $(window).scrollTop()) {
					$('#project-front-sections .project-front-sections').removeClass('fixed');
				} else if (($('#project-front-sections').offset().top <= $(window).scrollTop()) && ($('#project-front-list').offset().top + $('#project-front-list').outerHeight()) > ($(window).scrollTop() + $('#project-front-sections .project-front-sections').outerHeight())) {
					$('#project-front-sections .project-front-sections').addClass('fixed');
					$('#project-front-sections .project-front-sections').css('top', '0');
				} else if ($('#project-front-sections .project-front-sections').height() < $('#project-front-list').height()) {
					$('#project-front-sections .project-front-sections').removeClass('fixed');
					$('#project-front-sections .project-front-sections').css('top', ($('#project-front-list').outerHeight() - $('#project-front-sections .project-front-sections').outerHeight()) + 'px');
				} else if ($('#project-front-sections .project-front-sections').height() >= $('#project-front-list').height()) {
					$('#project-front-sections .project-front-sections').removeClass('fixed');
					$('#project-front-sections .project-front-sections').css('top', '0px');
				}
			}
		});


		var $grid = $('#project-front-list').isotope({
			itemSelector: '.project-front',
			layoutMode: 'fitRows'
		});
		$('#project-front-sections').on('click', 'a', function() {
			var filterValue = $( this ).attr('data-section');
			$grid.isotope({ filter: filterValue });
		});
		$('#project-front-sections').each( function( i, buttonGroup ) {
			var $buttonGroup = $( buttonGroup );
			$buttonGroup.on('click', 'a', function() {
				$buttonGroup.find('.active').removeClass('active');
				$( this ).addClass('active');
				return false;
			});
		});
	}

	
	// Blog Posts Categories - Fixed Block
	if ($('#blog-sections').length > 0) {
		$(window).scroll(function() {
			if ($(window).width() > 1123) { // 1140
				if ($('#blog-sections').offset().top > $(window).scrollTop()) {
					$('#blog-sections .blog-sections').removeClass('fixed');
				} else if (($('#blog-sections').offset().top <= $(window).scrollTop()) && ($('#blog-list').offset().top + $('#blog-list').outerHeight()) > ($(window).scrollTop() + $('#blog-sections .blog-sections').outerHeight())) {
					$('#blog-sections .blog-sections').addClass('fixed');
					$('#blog-sections .blog-sections').css('top', '0');
				} else {
					$('#blog-sections .blog-sections').removeClass('fixed');
					$('#blog-sections .blog-sections').css('top', ($('#blog-list').outerHeight() - $('#blog-sections .blog-sections').outerHeight()) + 'px');
				}
			}
		});
	}
	

	// Blog Posts - Show More with AJAX
	$('#blog-showmore').on('click', function(e){
		$(this).addClass('load');
		$.ajax({
			type: 'POST',
			url: 'php/showmore.php',
			data: { post_type: 'blog' },
			success: function(data) {					
				var items = $(data);
				items.addClass('hidden');
				$('#blog-list').append(items);
				$('#blog-showmore').removeClass('load');

				if ($(data).find('.blog-slider').length > 0) {
					$('.blog-slider').flexslider({
					    animation: "fade",
					    animationSpeed: 500,
					    slideshow: false,
					    animationLoop: false,
					    directionNav: false,
					    smoothHeight: false,
						controlNav: true,
					});
				}

				setTimeout(function() {
					items.removeClass('hidden').addClass('show');
				}, 10);
			},
			error: function(){
				alert('Error');
			}
		});
		return false;
	});


	// Homepage Projects - Show More with AJAX
	$('#project-front-more').on('click', function(e){
		$(this).addClass('load');
		$.ajax({
			type: 'POST',
			url: 'php/showmore.php',
			data: { post_type: 'project-front' },
			success: function(data) {
				var items = $(data);
				$('#project-front-list').append(items).each(function(){
					$('#project-front-list').isotope('reloadItems');
				});
				$('#project-front-list').isotope();

				$('#project-front-more').removeClass('load');
			},
			error: function(){
				alert('Error');
			}
		});
		return false;
	});

});
