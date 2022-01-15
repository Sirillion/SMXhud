using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class XUiC_Spinner : XUiController
{ 

    private bool isSpinning;
    private int spinSpeedAngle;
    private float rotation;


	public override void Update(float _dt)
    {
        base.Update(_dt);
        if(base.ViewComponent.IsVisible && isSpinning)
        {
            float deltaAngle = _dt * spinSpeedAngle;
            rotation = (rotation + deltaAngle)%360;
            if (rotation < 0)
            {
                rotation += 360;
            }
            ViewComponent.UiTransform.localEulerAngles = new Vector3(0f, 0f, this.rotation);
        }
        
    }

    public override bool ParseAttribute(string name, string value, XUiController _parent)
    {
        bool flag = base.ParseAttribute(name, value, _parent);
        if (flag)
        {
            return flag;
        }
        if (name != null && name == "spin")
        {
            isSpinning = StringParsers.ParseBool(value, 0, -1, true);
            return true;
        }
        if(name != null && name == "angle_per_second")
        {
            int.TryParse(value, out spinSpeedAngle);
            return true;
        }
        return false;
    }
}