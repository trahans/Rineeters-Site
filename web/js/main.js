$(document).ready(function(){
	$(document).on('click', function(){
		var navbarOpened = $(".navbar-collapse").hasClass("navbar-collapse menu collapse in");
		if (window.innerWidth <= 768 && navbarOpened === true) {
			$('.navbar-collapse').collapse('toggle');
		}
	});
})