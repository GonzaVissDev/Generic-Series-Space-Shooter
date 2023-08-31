using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUpFactory{  
    PowerUp Create(string id, Transform position);
}
