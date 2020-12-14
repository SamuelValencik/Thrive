using Godot;
using System;
using System.Collections.Generic;

public class MicrobeStub : Microbe
{

    public MicrobeStub()
    {
        Node world = new Node();


        world.AddChild(this);

        Membrane membrane = new Membrane();
        membrane.Name = "Membrane";
        membrane.Scale = new Vector3(1, 1, 1);
        Spatial OrganelleParent = new Spatial();
        OrganelleParent.Name = "OrganelleParent";
        AudioStreamPlayer3D EngulfAudio = new AudioStreamPlayer3D();
        EngulfAudio.Name = "EngulfAudio";
        AudioStreamPlayer3D MovementAudio = new AudioStreamPlayer3D();
        MovementAudio.Name = "MovementAudio";
        Area EngulfDetector = new Area();
        EngulfDetector.Name = "EngulfDetector";
        CollisionShape EngulfShape = new CollisionShape();
        EngulfShape.Name = "EngulfShape";
        EngulfShape.Shape = new SphereShape();

        this.AddChild(membrane);
        this.AddChild(OrganelleParent);
        this.AddChild(EngulfAudio);
        this.AddChild(MovementAudio);
        this.AddChild(EngulfDetector);

        
        EngulfDetector.AddChild(EngulfShape);

        MicrobeSpecies species = new MicrobeSpecies(0);
        MembraneType membraneType = new MembraneType();

        species.MembraneType = membraneType;

        OrganelleDefinition od = new OrganelleDefinition();

        OrganelleDefinition.OrganelleComponentFactoryInfo organelleComponentFactoryInfo = new OrganelleDefinition.OrganelleComponentFactoryInfo();
        od.Components = organelleComponentFactoryInfo;

        od.Hexes = new List<Hex>();
        od.Hexes.Add(new Hex(0, 0));
        od.InitialComposition = new Dictionary<Compound, float>();
        species.Organelles.Add(new OrganelleTemplateStub(od));

        GameProperties gameProperties = GameProperties.StartNewMicrobeGame();

        this.Init(new CompoundCloudSystem(), gameProperties, false);


        this.ApplySpecies(species);


    }
}
