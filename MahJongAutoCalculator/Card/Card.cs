using System.Runtime.InteropServices.Swift;
using System.Xml.XPath;

public abstract class Card: IEquatable<Card>, IComparable<Card> {
	public static int Compare(Card pLhs, Card pRhs) => pLhs.CompareTo(pRhs);
    
	protected abstract int OrderNumber { get; }
	public abstract CardType Type { get; }
	public bool IsAbleToStraight => (Type & CardType.LetterMask) == CardType.None;
	public abstract bool IsGreen { get; }
    
	//==================================================||Methods 
	public abstract bool Equals(Card? pOther);
	public abstract void MoveNext();
	protected abstract int CompareToSameType(Card pOther);

	public static IEnumerable<Card> Parse(string pContext) {
		var result = new List<Card>();
		var numbers = new List<int>();
		foreach (var c in pContext) {
			if (char.IsDigit(c)) {
				numbers.Add(c - '0');
				continue;
			}

			NumberType? type = c switch {
				'm' => NumberType.Money,
				's' => NumberType.Bamboo,
				'p' => NumberType.Wheel,
				_ => null
			};
			if (type == null) {
				foreach (var number in numbers) {
					Card newCard = number switch {
						1 => new WindCard(WindDirection.East),
						2 => new WindCard(WindDirection.South),
						3 => new WindCard(WindDirection.West),
						4 => new WindCard(WindDirection.North),
						5 => new LetterCard(LetterType.White),
						6 => new LetterCard(LetterType.Bloom),
						7 => new LetterCard(LetterType.Middle),
						_ => throw new ArgumentOutOfRangeException()
					};
					result.Add(newCard); 
				}
			}
			else {
				foreach (var number in numbers)
					result.Add(new NumberCard((NumberType)type, number, false));	
			}

			
			numbers.Clear();
		}

		return result;
	}
    
	public int CompareTo(Card? pOther) {
		if (ReferenceEquals(this, pOther)) return 0;
		if (pOther is null) return 1;
		if (GetType() != pOther.GetType()) return OrderNumber.CompareTo(pOther.OrderNumber);
		return CompareToSameType(pOther);
	}
}