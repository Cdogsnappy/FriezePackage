
var slider = $("sidesRange");
var slideVal = $("slidingVal");
var run = $("run");
slideVal.innerHTML = slider.value;

slider.oninput = function(){
    slideVal.innerHTML = this.value;
}

run.oninput = function(){

}
