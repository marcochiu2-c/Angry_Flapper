using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[DiagramInfoAttribute("NewProjectRepository")]
public class BirdViewModelBase : ViewModel {
    
    public P<BirdState> _StateProperty;
    
    public P<Single> _MaxSpeedProperty;
    
    public P<Single> _FlapVelocityProperty;
    
    protected CommandWithSender<BirdViewModel> _Hit;
    
    public BirdViewModelBase(BirdControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public BirdViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _StateProperty = new P<BirdState>(this, "State");
        _MaxSpeedProperty = new P<Single>(this, "MaxSpeed");
        _FlapVelocityProperty = new P<Single>(this, "FlapVelocity");
    }
}

public partial class BirdViewModel : BirdViewModelBase {
    
    private AngryFlappersGameViewModel _ParentAngryFlappersGame;
    
    public BirdViewModel(BirdControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public BirdViewModel() : 
            base() {
    }
    
    public virtual P<BirdState> StateProperty {
        get {
            return this._StateProperty;
        }
    }
    
    public virtual BirdState State {
        get {
            return _StateProperty.Value;
        }
        set {
            _StateProperty.Value = value;
        }
    }
    
    public virtual P<Single> MaxSpeedProperty {
        get {
            return this._MaxSpeedProperty;
        }
    }
    
    public virtual Single MaxSpeed {
        get {
            return _MaxSpeedProperty.Value;
        }
        set {
            _MaxSpeedProperty.Value = value;
        }
    }
    
    public virtual P<Single> FlapVelocityProperty {
        get {
            return this._FlapVelocityProperty;
        }
    }
    
    public virtual Single FlapVelocity {
        get {
            return _FlapVelocityProperty.Value;
        }
        set {
            _FlapVelocityProperty.Value = value;
        }
    }
    
    public virtual CommandWithSender<BirdViewModel> Hit {
        get {
            return _Hit;
        }
        set {
            _Hit = value;
        }
    }
    
    public virtual AngryFlappersGameViewModel ParentAngryFlappersGame {
        get {
            return this._ParentAngryFlappersGame;
        }
        set {
            _ParentAngryFlappersGame = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var bird = controller as BirdControllerBase;
        this.Hit = new CommandWithSender<BirdViewModel>(this, bird.Hit);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		stream.SerializeInt("State", (int)this.State);
        stream.SerializeFloat("MaxSpeed", this.MaxSpeed);
        stream.SerializeFloat("FlapVelocity", this.FlapVelocity);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		this.State = (BirdState)stream.DeserializeInt("State");
        		this.MaxSpeed = stream.DeserializeFloat("MaxSpeed");;
        		this.FlapVelocity = stream.DeserializeFloat("FlapVelocity");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_StateProperty, false, false, true));
        list.Add(new ViewModelPropertyInfo(_MaxSpeedProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_FlapVelocityProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("Hit", Hit) { ParameterType = typeof(void) });
    }
}

[DiagramInfoAttribute("NewProjectRepository")]
public class PipeViewModelBase : ViewModel {
    
    protected CommandWithSender<PipeViewModel> _Passed;
    
    protected CommandWithSender<PipeViewModel> _RemoveFromScreen;
    
    public PipeViewModelBase(PipeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public PipeViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
    }
}

public partial class PipeViewModel : PipeViewModelBase {
    
    private AngryFlappersGameViewModel _ParentAngryFlappersGame;
    
    public PipeViewModel(PipeControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public PipeViewModel() : 
            base() {
    }
    
    public virtual CommandWithSender<PipeViewModel> Passed {
        get {
            return _Passed;
        }
        set {
            _Passed = value;
        }
    }
    
    public virtual CommandWithSender<PipeViewModel> RemoveFromScreen {
        get {
            return _RemoveFromScreen;
        }
        set {
            _RemoveFromScreen = value;
        }
    }
    
    public virtual AngryFlappersGameViewModel ParentAngryFlappersGame {
        get {
            return this._ParentAngryFlappersGame;
        }
        set {
            _ParentAngryFlappersGame = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var pipe = controller as PipeControllerBase;
        this.Passed = new CommandWithSender<PipeViewModel>(this, pipe.Passed);
        this.RemoveFromScreen = new CommandWithSender<PipeViewModel>(this, pipe.RemoveFromScreen);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("Passed", Passed) { ParameterType = typeof(void) });
        list.Add(new ViewModelCommandInfo("RemoveFromScreen", RemoveFromScreen) { ParameterType = typeof(void) });
    }
}

[DiagramInfoAttribute("NewProjectRepository")]
public class AngryFlappersGameViewModelBase : ViewModel {
    
    public P<BirdViewModel> _BirdProperty;
    
    public P<AngryFlappersGameState> _StateProperty;
    
    public P<Int32> _ScoreProperty;
    
    public P<Single> _GravityProperty;
    
    public P<Single> _PipeSpawnSeedProperty;
    
    public P<Single> _ScrollSpeedProperty;
    
    public P<Int32> _TryProperty;
    
    public ModelCollection<PipeViewModel> _PipesProperty;
    
    protected CommandWithSender<AngryFlappersGameViewModel> _GameOver;
    
    protected CommandWithSender<AngryFlappersGameViewModel> _Play;
    
    protected CommandWithSender<AngryFlappersGameViewModel> _GoToMenu;
    
    public AngryFlappersGameViewModelBase(AngryFlappersGameControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public AngryFlappersGameViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _BirdProperty = new P<BirdViewModel>(this, "Bird");
        _StateProperty = new P<AngryFlappersGameState>(this, "State");
        _ScoreProperty = new P<Int32>(this, "Score");
        _GravityProperty = new P<Single>(this, "Gravity");
        _PipeSpawnSeedProperty = new P<Single>(this, "PipeSpawnSeed");
        _ScrollSpeedProperty = new P<Single>(this, "ScrollSpeed");
        _TryProperty = new P<Int32>(this, "Try");
        _PipesProperty = new ModelCollection<PipeViewModel>(this, "Pipes");
        _PipesProperty.CollectionChanged += PipesCollectionChanged;
    }
    
    protected virtual void PipesCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
    }
}

public partial class AngryFlappersGameViewModel : AngryFlappersGameViewModelBase {
    
    public AngryFlappersGameViewModel(AngryFlappersGameControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public AngryFlappersGameViewModel() : 
            base() {
    }
    
    public virtual P<BirdViewModel> BirdProperty {
        get {
            return this._BirdProperty;
        }
    }
    
    public virtual BirdViewModel Bird {
        get {
            return _BirdProperty.Value;
        }
        set {
            _BirdProperty.Value = value;
            if (value != null) value.ParentAngryFlappersGame = this;
        }
    }
    
    public virtual P<AngryFlappersGameState> StateProperty {
        get {
            return this._StateProperty;
        }
    }
    
    public virtual AngryFlappersGameState State {
        get {
            return _StateProperty.Value;
        }
        set {
            _StateProperty.Value = value;
        }
    }
    
    public virtual P<Int32> ScoreProperty {
        get {
            return this._ScoreProperty;
        }
    }
    
    public virtual Int32 Score {
        get {
            return _ScoreProperty.Value;
        }
        set {
            _ScoreProperty.Value = value;
        }
    }
    
    public virtual P<Single> GravityProperty {
        get {
            return this._GravityProperty;
        }
    }
    
    public virtual Single Gravity {
        get {
            return _GravityProperty.Value;
        }
        set {
            _GravityProperty.Value = value;
        }
    }
    
    public virtual P<Single> PipeSpawnSeedProperty {
        get {
            return this._PipeSpawnSeedProperty;
        }
    }
    
    public virtual Single PipeSpawnSeed {
        get {
            return _PipeSpawnSeedProperty.Value;
        }
        set {
            _PipeSpawnSeedProperty.Value = value;
        }
    }
    
    public virtual P<Single> ScrollSpeedProperty {
        get {
            return this._ScrollSpeedProperty;
        }
    }
    
    public virtual Single ScrollSpeed {
        get {
            return _ScrollSpeedProperty.Value;
        }
        set {
            _ScrollSpeedProperty.Value = value;
        }
    }
    
    public virtual P<Int32> TryProperty {
        get {
            return this._TryProperty;
        }
    }
    
    public virtual Int32 Try {
        get {
            return _TryProperty.Value;
        }
        set {
            _TryProperty.Value = value;
        }
    }
    
    public virtual ModelCollection<PipeViewModel> Pipes {
        get {
            return this._PipesProperty;
        }
    }
    
    public virtual CommandWithSender<AngryFlappersGameViewModel> GameOver {
        get {
            return _GameOver;
        }
        set {
            _GameOver = value;
        }
    }
    
    public virtual CommandWithSender<AngryFlappersGameViewModel> Play {
        get {
            return _Play;
        }
        set {
            _Play = value;
        }
    }
    
    public virtual CommandWithSender<AngryFlappersGameViewModel> GoToMenu {
        get {
            return _GoToMenu;
        }
        set {
            _GoToMenu = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var angryFlappersGame = controller as AngryFlappersGameControllerBase;
        this.GameOver = new CommandWithSender<AngryFlappersGameViewModel>(this, angryFlappersGame.GameOver);
        this.Play = new CommandWithSender<AngryFlappersGameViewModel>(this, angryFlappersGame.Play);
        this.GoToMenu = new CommandWithSender<AngryFlappersGameViewModel>(this, angryFlappersGame.GoToMenu);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
		if (stream.DeepSerialize) stream.SerializeObject("Bird", this.Bird);
		stream.SerializeInt("State", (int)this.State);
        stream.SerializeInt("Score", this.Score);
        stream.SerializeFloat("Gravity", this.Gravity);
        stream.SerializeFloat("PipeSpawnSeed", this.PipeSpawnSeed);
        stream.SerializeFloat("ScrollSpeed", this.ScrollSpeed);
        stream.SerializeInt("Try", this.Try);
        if (stream.DeepSerialize) stream.SerializeArray("Pipes", this.Pipes);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
		if (stream.DeepSerialize) this.Bird = stream.DeserializeObject<BirdViewModel>("Bird");
		this.State = (AngryFlappersGameState)stream.DeserializeInt("State");
        		this.Score = stream.DeserializeInt("Score");;
        		this.Gravity = stream.DeserializeFloat("Gravity");;
        		this.PipeSpawnSeed = stream.DeserializeFloat("PipeSpawnSeed");;
        		this.ScrollSpeed = stream.DeserializeFloat("ScrollSpeed");;
        		this.Try = stream.DeserializeInt("Try");;
if (stream.DeepSerialize) {
        this.Pipes.Clear();
        this.Pipes.AddRange(stream.DeserializeObjectArray<PipeViewModel>("Pipes"));
}
    }
    
    public override void Unbind() {
        base.Unbind();
        _PipesProperty.CollectionChanged -= PipesCollectionChanged;
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_BirdProperty, true, false, false));
        list.Add(new ViewModelPropertyInfo(_StateProperty, false, false, true));
        list.Add(new ViewModelPropertyInfo(_ScoreProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_GravityProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_PipeSpawnSeedProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_ScrollSpeedProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_TryProperty, false, false, false));
        list.Add(new ViewModelPropertyInfo(_PipesProperty, true, true, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("GameOver", GameOver) { ParameterType = typeof(void) });
        list.Add(new ViewModelCommandInfo("Play", Play) { ParameterType = typeof(void) });
        list.Add(new ViewModelCommandInfo("GoToMenu", GoToMenu) { ParameterType = typeof(void) });
    }
    
    protected override void PipesCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
        foreach (var item in args.NewItems.OfType<PipeViewModel>()) item.ParentAngryFlappersGame = this;;
    }
}

[DiagramInfoAttribute("NewProjectRepository")]
public class MenuRootViewModelBase : ViewModel {
    
    public P<Int32> _ScoreProperty;
    
    protected CommandWithSender<MenuRootViewModel> _GoToGame;
    
    public MenuRootViewModelBase(MenuRootControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MenuRootViewModelBase() : 
            base() {
    }
    
    public override void Bind() {
        base.Bind();
        _ScoreProperty = new P<Int32>(this, "Score");
    }
}

public partial class MenuRootViewModel : MenuRootViewModelBase {
    
    public MenuRootViewModel(MenuRootControllerBase controller, bool initialize = true) : 
            base(controller, initialize) {
    }
    
    public MenuRootViewModel() : 
            base() {
    }
    
    public virtual P<Int32> ScoreProperty {
        get {
            return this._ScoreProperty;
        }
    }
    
    public virtual Int32 Score {
        get {
            return _ScoreProperty.Value;
        }
        set {
            _ScoreProperty.Value = value;
        }
    }
    
    public virtual CommandWithSender<MenuRootViewModel> GoToGame {
        get {
            return _GoToGame;
        }
        set {
            _GoToGame = value;
        }
    }
    
    protected override void WireCommands(Controller controller) {
        var menuRoot = controller as MenuRootControllerBase;
        this.GoToGame = new CommandWithSender<MenuRootViewModel>(this, menuRoot.GoToGame);
    }
    
    public override void Write(ISerializerStream stream) {
		base.Write(stream);
        stream.SerializeInt("Score", this.Score);
    }
    
    public override void Read(ISerializerStream stream) {
		base.Read(stream);
        		this.Score = stream.DeserializeInt("Score");;
    }
    
    public override void Unbind() {
        base.Unbind();
    }
    
    protected override void FillProperties(List<ViewModelPropertyInfo> list) {
        base.FillProperties(list);;
        list.Add(new ViewModelPropertyInfo(_ScoreProperty, false, false, false));
    }
    
    protected override void FillCommands(List<ViewModelCommandInfo> list) {
        base.FillCommands(list);;
        list.Add(new ViewModelCommandInfo("GoToGame", GoToGame) { ParameterType = typeof(void) });
    }
}

public enum AngryFlappersGameState {
    
    Menu,
    
    Playing,
    
    GameOver,
}

public enum BirdState {
    
    Alive,
    
    Dead,
}
