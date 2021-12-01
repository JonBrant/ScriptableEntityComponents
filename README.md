# ScriptableEntityComponents
Drag and drop behavior with ScriptableComponents

Basic usage:
Add an Entity component to a scene object. Then create one of the example ScriptableObjects by right clicking in your Pojects tab and going to ScriptableComponents>Components and selecting a ScriptableObject example.
Drag the created ScriptableComponent into the Entity's ScriptableComponent list.

To make your own ScriptableComponent, simply inherit from ScriptableComponent. Be sure to add a CreateAssetMenu for it, and then add any interfaces you like.

For example, IAwake will cause the Entity to execute its method in the Entity's Awake method. ITick will cause it to execute ITick's Tick method in Entity's Update method.
