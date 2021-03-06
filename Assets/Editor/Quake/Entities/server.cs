using System;

using UnityEngine;

[EntityGroup("Monsters")]
public abstract class monster_entity_t : entity_t
{
    public monster_entity_t()
    {
        this.movable = true;
    }

    public override void SetupInstance(BSPFile bsp, entity entity, SceneEntities entities)
    {
        base.SetupInstance(bsp, entity, entities);

        if (angle >= 0 && angle < 360)
        {
            entity.transform.rotation = Quaternion.AngleAxis(90 - angle, Vector3.up);
        }
        else
        {
            Debug.LogError("Unexpected angle: " + angle);
        }
    }
}

public class monster_ogre_t : monster_entity_t
{
}

public class monster_demon1_t : monster_entity_t
{
}

public class monster_shambler_t : monster_entity_t
{
}

public class monster_knight_t : monster_entity_t
{
}

public class monster_army_t : monster_entity_t
{
}

public class monster_wizard_t : monster_entity_t
{
}

public class monster_dog_t : monster_entity_t
{
}

public class monster_zombie_t : monster_entity_t
{
    public override void SetupInstance(BSPFile bsp, entity entity, SceneEntities entities)
    {
        base.SetupInstance(bsp, entity, entities);

        if (this.spawnflags == 1) // not sure what this value means but it might be "crucified"
        {
            var rigidBoby = entity.GetComponent<Rigidbody>();
            if (rigidBoby != null)
            {
                GameObject.DestroyImmediate(rigidBoby);
            }

            var collider = entity.GetComponent<BoxCollider>();
            if (collider != null)
            {
                GameObject.DestroyImmediate(collider);
            }

            var zombie = entity as monster_zombie;
            zombie.crucified = true;
        }
    }
}

public class monster_boss_t : monster_entity_t
{
}

public class monster_tarbaby_t : monster_entity_t
{
}

public class monster_hell_knight_t : monster_entity_t
{
}

public class monster_fish_t : monster_entity_t
{
}

public class monster_shalrath_t : monster_entity_t
{
}

public class monster_enforcer_t : monster_entity_t
{
}

public class monster_oldone_t : monster_entity_t
{
}

public class event_lightning_t : entity_t
{
}

/*
 * (0.5 0.3 0) (-8 -8 -8) (8 8 8)
 * Monsters will continue walking towards the next target corner.
 */
public class path_corner_t : entity_t
{
}
