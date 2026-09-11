namespace Ichihime.Mahjong;

public abstract class Mentsu(bool isMenzen) {

	public abstract int Size { get; }
	public abstract int Fu { get; }
	public bool IsMenzen => isMenzen;

	public abstract ICollection<Hai> Hais { get; }

}