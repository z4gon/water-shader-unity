# Water Shader

With Shader Graph in **Unity 2021.3.0f1**

## Fatures

- [Water depth color fade](#water-depth-effect)
- [Refraction effect](#refraction-effect)
- Geometry displacement for wave effects
- Foam effect

## Screenshots

### Water depth effect

#### Progress

Water Depth = Scene Depth - Fragment Position
![Water depth effect](./docs/screenshots/water_depth.gif)

Lerping between the two colors
![Water depth effect](./docs/screenshots/water_depth_colored.gif)

#### Sub Graph for the depth fade effect

[Sub Graph example by Binary Lunar](https://www.youtube.com/watch?v=MHdDUqJHJxM)

Calculates the depth of the water using the Scene Depth node and the Screen Postion node. Then scales it down and clamps it to a 0..1 value to be able to use it for lerping colors later.
![Depth fade sub graph](./docs/screenshots/depth_fade_sub_graph.png)

#### Understanding Fragment Depth vs Scene Depth (Depth Texture)

[Depth by Cyanilux](https://www.cyanilux.com/tutorials/depth/#scene-depth-node)

How objects that are occluded by the object with the shader are used by the shader.
![Depth fade sub graph](./docs/screenshots/fragment_depth_vs_scene_depth.png)

#### Water color section (lerp)

Lerp between shallow water color and deep water color, using the Depth Fade sub graph
![Water color section](./docs/screenshots/water_color_section.png)

---

### Refraction effect

#### UV Movement sub graph

[Sub Graph example by Binary Lunar](https://www.youtube.com/watch?v=MHdDUqJHJxM)

Tiles and offsets UV coordinates given a speed and a scale
![UV Movement sub graph](./docs/screenshots/uv_movement_sub_graph.png)

---

### Scene objects setup

Integrating low poly assets from the asset store

[Low-Poly Simple Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)

![Scene objects setup](./docs/screenshots/scene_objects.gif)

---

## Implementation explained

1. **Project configuration**

   1. Use the Universal Render Pipeline
   1. In the Scriptable Object asset for the Render Pipeline Enable:
      - Depth Texture
      - Opaque Texture

1. **Water depth effect**

   1. **Make a "Depth Fade" Sub Graph using:**

      1. **Scene Depth Node** with Eye sampling (Depth Texture)
      1. **Screen Position Node** with Raw mode (Fragment Position)

         > Take just the Aplha channel which contains the Fragment Postion

      1. Substract these two to calculate **"Water Depth" = Scene Depth 1. Fragment Position**

      1. Divide by a scaling factor to dynamically adjust the fading color for the water depth via property

      1. Finally clamp the value to (0,1) to use it as lerp between two colors (shallow and deep water)

   1. **Shader for the Water**

      1. Make the Shader's Surface Type transparent

   1. **Depth color fade**

      1. Use the Sub Graph to lerp between two colors (shallow and deep water)

1. **Refraction effect**

   1. **Make a "UV Movement" Sub Graph using:**

      1. Time node to have a looping time value
      1. Speed input to make the time go faster or slower
      1. Tiling and Offset node to transform the UVs
      1. Scale inpupt to affect tiling
      1. Output the Vector2 which will affect the UVs of the refraction later

1. **Apply to object**
   1. Create a Material with the Shader and apply it to the Water plane
