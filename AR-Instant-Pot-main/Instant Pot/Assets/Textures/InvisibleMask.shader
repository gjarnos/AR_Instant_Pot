Shader "Custom/InvisibleMask" {
    SubShader{
        // draw after all opaque objects (queue = 2001):
        Tags { "Queue" = "Geometry+1" }
        ColorMask 0
        ZWrite On
        Pass {
          Blend Zero One // keep the image behind it
        }
    }
}
