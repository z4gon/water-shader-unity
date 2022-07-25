# Water Shader

With Shader Graph in **Unity 2021.3.0f1**

## Fatures

- [Water depth color fade](#water-depth-effect)
- Refraction effect
- Geometry displacement for wave effects
- Foam effect

## Implementation explained

- Use Universal Render Pipeline
- Enable Depth Texture and Opaque Texture in the Scriptable Object for the Render Pipeline
- Make a Sub Graph that calculates a (0,1) value using:
  - Scene Depth Node with Eye sampling (Depth Texture)
  - Screen Position Node (Fragment Position)
  - Substract these to calculate "Water Depth" = Scene Depth - Fragment Depth
  - Divide by a scaling factor to dynamically adjust the fading color for the water depth via property
  - Finally clamp the value to (0,1) to use it as lerp between two colors (shallow and deep water)
- Create a Material with a Shader for the Water
  - Make the Shader's Surface Type transparent
  - Apply the Shader to the plane and make the plane not cast shadows

## Screenshots

### Water depth effect

![Water depth effect](./docs/screenshots/water_depth.gif)
![Water depth effect](./docs/screenshots/water_depth_colored.gif)

#### Sub Graph for the depth fade effect

[Sub Graph example by Binary Lunar](https://www.youtube.com/watch?v=MHdDUqJHJxM)

![Depth fade sub graph](./docs/screenshots/depth_fade_sub_graph.png)

#### Understanding Fragment Depth vs Scene Depth (Depth Texture)

[Depth by Cyanilux](https://www.cyanilux.com/tutorials/depth/#scene-depth-node)

![Depth fade sub graph](./docs/screenshots/fragment_depth_vs_scene_depth.png)

---

### Scene objects setup

Integrating low poly assets from the asset store

[Low-Poly Simple Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)

![Scene objects setup](./docs/screenshots/scene_objects.gif)
