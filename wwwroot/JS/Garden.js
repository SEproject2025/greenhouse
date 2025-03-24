
//***************************************************************************************
// Updates the progress circles on the plant tiles
//***************************************************************************************
function updateProgressCircles() {
    document.querySelectorAll(".circular-progress").forEach((progressBar) => {
        let value = parseInt(progressBar.getAttribute("data-percentage"));

        // Ensure value is between 0 and 100
        value = Math.max(0, Math.min(value, 100));

        // Apply the conic-gradient for progress
        progressBar.style.background = `conic-gradient(green ${value * 3.6}deg, lightgray ${value * 3.6}deg)`;
    });
}

document.addEventListener("DOMContentLoaded", updateProgressCircles);

//***************************************************************************************
// Called when the user starts dragging the watering can; stores a custom value
//***************************************************************************************
function handleDragStart(event) {
    event.dataTransfer.setData("text/plain", "watering-can");

    // Change the image to PourWateringCan.png while dragging
    const img = document.getElementById("watering-can");
    if (img) {
        img.src = "/plant_tasks/PourWateringCan.png";
        }
}

//***************************************************************************************
// Called when the user starts dragging the watering can
//***************************************************************************************
function handleDragStart(event)
{
    // Set a custom data type and value to identify what is being dragged
    event.dataTransfer.setData("text/plain", "watering-can");

    // Create a new image element that will be shown under the mouse pointer while dragging
    const dragImage = new Image();
    dragImage.src = "/plant_tasks/PourWateringCan.png";

    // Inline styling (drag image size) to match the original watering can size
    dragImage.style.width = "90px";
    dragImage.style.height = "auto";

    // Prevent visual flickering by positioning the image offscreen
    dragImage.style.position = "absolute";
    dragImage.style.top = "-1000px";

    // Append the image to the body so styling can be applied before it's used
    document.body.appendChild(dragImage); // Needed in some browsers to apply styling

    // Use the new image as the drag preview with centered offset
    event.dataTransfer.setDragImage(dragImage, 45, 45); // Centered on pointer
    }

//***************************************************************************************
// Triggered when the watering can is dropped onto a tile
// Invokes the Blazor Method - CompleteWateringTask()
//***************************************************************************************
function handleDrop(event, plantId)
{
    event.preventDefault();
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper) {
        dotNetHelper.invokeMethodAsync("CompleteWateringTask", plantId);
        }
}

//***************************************************************************************
// Registers a .NET helper reference for later JS-to-blazor calls
//***************************************************************************************
window.setDotNetHelper = function (dotNetHelper) {
    window.dotNetHelperRef = dotNetHelper;
};
