window.triggerConfettiFromCheckbox = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 100;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 15, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 10, // Increase launch speed
            origin: { x, y },
            colors: ['#90EE90'] // More colors
        });
    }, 1);
};

window.rainbowConfetti = () => {
    var end = Date.now() + 2000; // Confetti rains for 3 seconds
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 300, // Moderate amount of confetti per burst
            angle: 90, // Confetti falls straight down
            spread: 200, // Wide spread
            startVelocity: 40, // falling speed
            decay: 0.85, // Slower decay so it falls farther
            origin: { x: 0.4 + Math.random() * 0.2, y: 0 }, // Starts randomly from the top
            colors: ['#FF0000', '#FF7F00', '#FFFF00', '#00FF00', '#0000FF', '#4B0082', '#9400D3'] // Rainbow colors
        });
    }, 100); // Fires every 100ms
};