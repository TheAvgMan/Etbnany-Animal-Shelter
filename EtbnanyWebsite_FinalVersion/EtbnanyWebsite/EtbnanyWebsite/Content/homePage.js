document.addEventListener('DOMContentLoaded', function () {
    let slideIndex = 0;




    function showSlide(n) {
        const slides = document.getElementsByClassName("slides");
        if (n >= slides.length) { slideIndex = 0 }
        if (n < 0) { slideIndex = slides.length - 1 }

        for (let i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slides[slideIndex].style.display = "block";
    }

    function changeSlide(n) {
        showSlide(slideIndex += n);
    }

    // Automatically advance slides every 5 seconds
    setInterval(() => {
        changeSlide(1);
    }, 5000);

    // Initial slide display
    showSlide(slideIndex);
});

