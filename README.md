# VRHF_2022
 Exercise to the "Virtual Reality in Human Factors Research" lecture.

## Notes and issues:
### General:
 - My code slightly differs from the code proposed in the exercise script. But I try to comment everything in the code.
### Week 2: (Done)
 - nothing special
### Week 3: (Done)
 - I didn't manage to create trees bended by wind. I suppose that URP doesn't fully support the Speed tree shaders (yet). That's why the trees in the scene are static. Also: The Tree component in the tree objects is very fragile. So don't touch it! It might break the shader fixes I did.
 - Cars turning was added using transform.LookAt(target).
### Week 4: (Done)
 - Buildings also got colliders, so the camera don't go inside them.
 - "ClipMoveTime" and "ClosestDistance" of "ProtectCameraFromWallClip" from the camera rig is set to 0, to never go inside colliders.
 - Idle rotation is put into a second layer to make the coin always rotate ![Animator](https://user-images.githubusercontent.com/17547258/169704##844-83851753-f5a3-41ba-b32b-3a1c759b1817.jpg)
 - Positioning the player to start position is called AFTER the collect animation is done. ![Animation](https://user-images.githubusercontent.com/17547258/169704928-50201c15-5180-467d-8ae0-3b1929958267.png)
### Week 5: (Done)
 - Two TrafficControllers were added, one for each car prefab.
 - startTarget was added into TrafficController to make the cars spawn from a different target.