﻿
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
// Called when the user starts dragging the watering can
//***************************************************************************************
function handleDragStart(event) {
    event.dataTransfer.setData("text", "watering");
}

//***************************************************************************************
// Called when the user starts dragging the pruning tool
//***************************************************************************************
function handlePruningDragStart(event)
{
    event.dataTransfer.setData("text", "pruning");
}

//***************************************************************************************
// Called when the user starts dragging the bug spray
//***************************************************************************************
function handlePestControlDragStart(event)
{
    event.dataTransfer.setData("text", "pestcontrol");
}

//***************************************************************************************
// Called when the user starts dragging the gloves
//***************************************************************************************
function handleWeedingDragStart(event)
{
    event.dataTransfer.setData("text", "weeding");
}

//***************************************************************************************
// Called when the user starts dragging the shovel
//***************************************************************************************
function handleShovelDragStart(event)
{
    event.dataTransfer.setData("text", "shovel");

}

//***************************************************************************************
// Central drop handler that delegates to the correct tool function
//***************************************************************************************
function handleGenericDrop(event, plantId) {
    event.preventDefault();
    const tool = event.dataTransfer.getData("text");

    switch (tool) {
        case "watering":
            handleWateringDrop(plantId);
            break;
        case "pruning":
            handlePruningDrop(plantId);
            break;
        case "pestcontrol":
            handlePestControlDrop(plantId);
            break;
        case "weeding":
            handleWeedingDrop(plantId);
            break;
        case "shovel":
            handleShovelDrop(plantId);
            break;
    }
}

//***************************************************************************************
// Separated drop handlers for each tool
//***************************************************************************************
function handleWateringDrop(plantId) {
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper) {
        dotNetHelper.invokeMethodAsync("CompleteWateringTask", plantId);
    }
}

function handlePruningDrop(plantId) {
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper) {
        dotNetHelper.invokeMethodAsync("CompletePruningTask", plantId);
    }
}

function handlePestControlDrop(plantId) {
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper) {
        dotNetHelper.invokeMethodAsync("CompletePestControlTask", plantId);
    }
}

function handleWeedingDrop(plantId) {
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper) {
        dotNetHelper.invokeMethodAsync("CompleteWeedingTask", plantId);
    }
}

//***************************************************************************************
// Drop handler for the shovel tool & style the modal
//***************************************************************************************
let pendingDeletePlantId = null;

function handleShovelDrop(plantId) {
    pendingDeletePlantId = plantId;
    document.getElementById("deleteConfirmModal").style.display = "flex";
}

function confirmDeletePlant() {
    const dotNetHelper = window.dotNetHelperRef;
    if (dotNetHelper && pendingDeletePlantId !== null) {
        dotNetHelper.invokeMethodAsync("DeletePlantByDrop", pendingDeletePlantId);
    }
    closeDeleteModal();
}

function closeDeleteModal() {
    document.getElementById("deleteConfirmModal").style.display = "none";
    pendingDeletePlantId = null;
}


//***************************************************************************************
// Registers a .NET helper reference for later JS-to-blazor calls
//***************************************************************************************
window.setDotNetHelper = function (dotNetHelper) {
    window.dotNetHelperRef = dotNetHelper;
};
