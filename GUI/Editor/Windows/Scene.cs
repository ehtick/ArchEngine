﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using ArchEngine.Core;
using ArchEngine.Core.ECS;
using ArchEngine.Core.Utils;
using ArchEngine.GUI.Editor.Windows;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Quaternion = OpenTK.Mathematics.Quaternion;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace ArchEngine.GUI.Editor.Windows
{
    public class Scene
    {
        public static void Draw()
        {
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(50,50), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(300, 300), ImGuiCond.FirstUseEver);
            ImGui.Begin("Scene");
            
            //pass the texture of the FBO
            //window.getRenderTexture() is the texture of the FBO
            //the next parameter is the upper left corner for the uvs to be applied at
            //the third parameter is the lower right corner
            //the last two parameters are the UVs
            //they have to be flipped (normally they would be (0,0);(1,1) 
            
            Vector2 vMin = ImGui.GetWindowContentRegionMin();
            Vector2 vMax = ImGui.GetWindowContentRegionMax();

            vMin.X += ImGui.GetWindowPos().X;
            vMin.Y += ImGui.GetWindowPos().Y;
            vMax.X += ImGui.GetWindowPos().X;
            vMax.Y += ImGui.GetWindowPos().Y;

            Vector2 size = (vMax - vMin);
            
            
            ImGui.GetWindowDrawList().AddImage(
                new IntPtr(Window._renderer.frameBuffer.frameBufferTexture), //use real pointer
                ImGui.GetCursorScreenPos(),
                new Vector2(ImGui.GetCursorScreenPos().X + size.X, 
                    ImGui.GetCursorScreenPos().Y + size.Y), new Vector2(0, 1), new Vector2(1, 0));


            //Resizes framebuffer:
            //GL.BindTexture(TextureTarget.Texture2D, Window._renderer.frameBuffer.frameBufferTexture);
            //GL.TexImage2D(TextureTarget.Texture2D,0,PixelInternalFormat.Rgb,(int)size.X,(int)size.Y,0,PixelFormat.Rgb,PixelType.UnsignedByte,IntPtr.Zero);

            ImGui.End();
            
        }
    }
}