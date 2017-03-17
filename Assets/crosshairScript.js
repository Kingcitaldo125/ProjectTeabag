//Script Help from: http://answers.unity3d.com/questions/35480/crosshair-how.html
var crosshairTexture : Texture2D;
var overTargetTexture : Texture2D;
var position : Rect;
static var OriginalOn = true;
var aspectRatio = 2;
var areADS = false;
var overTarget = false;
 
function Start()
{
    position = Rect((Screen.width - (crosshairTexture.width/aspectRatio)) / 2, (Screen.height - 
        (crosshairTexture.height/aspectRatio)) /2, crosshairTexture.width/aspectRatio, crosshairTexture.height/aspectRatio);
}

function Update()
{
    overTarget = false;
    if(Input.GetMouseButtonDown(1)&&areADS==false)
        areADS=true;
    else if(Input.GetMouseButtonDown(1)&&areADS==true)
        areADS=false;

    if(Input.GetButtonDown("gamepad_b")&&areADS==false)
        areADS=true;
    else if(Input.GetButtonDown("gamepad_b")&&areADS==true)
        areADS=false;
}
 
function OnGUI()
{
    if(OriginalOn == true && areADS==false && overTarget ==false)
        GUI.DrawTexture(position, crosshairTexture);
    if(OriginalOn == true && areADS==false && overTarget ==true)
        GUI.DrawTexture(position, overTargetTexture);
}
function onTopTarget()
{
    overTarget = true;
}