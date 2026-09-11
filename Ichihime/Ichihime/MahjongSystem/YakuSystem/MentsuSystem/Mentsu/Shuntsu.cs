namespace Ichihime.Mahjong;

public sealed class Shuntsu : Mentsu {

	//======================================================================| Fields

	private readonly Hai[] _hais;

	//======================================================================| Properties

	public override int Fu => 0;
	public override int Size => 3;
	public override ICollection<Hai> Hais => _hais;
		
	//======================================================================| Consturctors

	public Shuntsu(Hai hai1, Hai hai2, Hai hai3, Hai? furoHai = null) : base(furoHai is null) {

		_hais = [ hai1, hai2, hai3 ];

		if (!_hais.Contains(furoHai))
			throw new ArgumentException(null, nameof(furoHai));
			
	}

}