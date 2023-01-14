using Netris.Models.Parameters;
using Netris.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace Netris.ViewModels.Game.Pieces
{
    public class PieceFactory
    {
        private readonly Random random;
        private readonly List<PieceType> pieceTypes;
        private readonly List<PieceType> bagInts;

        public Func<PlayerViewModel, PieceViewModel> GetNextPiece { init; get; }

        public PieceFactory(ParametersViewModel parameters, bool isHost) 
        {
            random = new();
            pieceTypes = new();
            bagInts = new();

            if (isHost)
            {
                GetNextPiece = parameters.PieceGeneration.Type switch
                {
                    PieceGenerationType.Random => parameters.PieceGeneration.IsSynchronizedAcrossPlayers ? SharedRandom : Random,
                    PieceGenerationType.SevenBag => parameters.PieceGeneration.IsSynchronizedAcrossPlayers ? SharedSevenBag : SevenBag,
                    PieceGenerationType.Snakes => parameters.PieceGeneration.IsSynchronizedAcrossPlayers ? SharedSnakes : Snakes,
                    PieceGenerationType.IOnly => (board) => new I(board),
                    PieceGenerationType.JOnly => (board) => new J(board),
                    PieceGenerationType.ZOnly => (board) => new Z(board),
                    PieceGenerationType.LOnly => (board) => new L(board),
                    PieceGenerationType.UOnly => (board) => new U(board),
                    PieceGenerationType.TOnly => (board) => new T(board),
                    PieceGenerationType.SOnly => (board) => new S(board),
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                GetNextPiece = (board) => new I(board);
                /// I'm signing myself up for a load of net code...
            }
        }

        private PieceViewModel SevenBag(PlayerViewModel board)
        {
            if (bagInts.Count == 0)
            {
                bagInts.Add(PieceType.I);
                bagInts.Add(PieceType.S);
                bagInts.Add(PieceType.Z);
                bagInts.Add(PieceType.J);
                bagInts.Add(PieceType.L);
                bagInts.Add(PieceType.U);
                bagInts.Add(PieceType.T);
            }

            PieceType pieceNum = bagInts[random.Next(0, bagInts.Count)];
            PieceViewModel piece = GeneratePieceFromEnum(pieceNum, board);
            bagInts.Remove(pieceNum);
            pieceTypes.Add(pieceNum);
            return piece;
        }

        private PieceViewModel SharedSevenBag(PlayerViewModel board)
        {
            if (pieceTypes.Count < board.PiecesGenerated)
            {
                if (bagInts.Count == 0)
                {
                    bagInts.Add(PieceType.I);
                    bagInts.Add(PieceType.S);
                    bagInts.Add(PieceType.Z);
                    bagInts.Add(PieceType.J);
                    bagInts.Add(PieceType.L);
                    bagInts.Add(PieceType.U);
                    bagInts.Add(PieceType.T);
                }

                PieceType pieceNum = bagInts[random.Next(0, bagInts.Count)];
                bagInts.Remove(pieceNum);
                pieceTypes.Add(pieceNum);
            }

            return GeneratePieceFromEnum(pieceTypes[board.PiecesGenerated++], board);
        }

        private PieceViewModel Snakes(PlayerViewModel board)
        {

            if (bagInts.Count == 0)
            {
                bagInts.Add(PieceType.I);
                bagInts.Add(PieceType.S);
                bagInts.Add(PieceType.Z);
            }

            PieceType pieceNum = bagInts[random.Next(0, bagInts.Count)];
            PieceViewModel piece = GeneratePieceFromEnum(pieceNum, board);
            bagInts.Remove(pieceNum);
            return piece;
        }

        private PieceViewModel SharedSnakes(PlayerViewModel board)
        {
            if (pieceTypes.Count == board.PiecesGenerated)
            {
                if (bagInts.Count == 0)
                {
                    bagInts.Add(PieceType.I);
                    bagInts.Add(PieceType.S);
                    bagInts.Add(PieceType.Z);
                }

                PieceType pieceNum = bagInts[random.Next(0, bagInts.Count)];
                bagInts.Remove(pieceNum);
                pieceTypes.Add(pieceNum);
            }

            return GeneratePieceFromEnum(pieceTypes[board.PiecesGenerated++], board);
        }

        private PieceViewModel Random(PlayerViewModel board)
        {
            return random.Next(0, 7) switch
            {
                0 => new I(board),
                1 => new T(board),
                2 => new S(board),
                3 => new Z(board),
                4 => new L(board),
                5 => new J(board),
                6 => new U(board),
                _ => new Empty(board),
            };
        }

        private PieceViewModel SharedRandom(PlayerViewModel board)
        {

            if (pieceTypes.Count == board.PiecesGenerated)
            {
                pieceTypes.Add((PieceType)random.Next(0, 7));
            }

            return GeneratePieceFromEnum(pieceTypes[board.PiecesGenerated++], board);
        }

        private static PieceViewModel GeneratePieceFromEnum(PieceType piece, PlayerViewModel board)
        {
            return piece switch
            {
                PieceType.I => new I(board),
                PieceType.T => new T(board),
                PieceType.S => new S(board),
                PieceType.Z => new Z(board),
                PieceType.L => new L(board),
                PieceType.J => new J(board),
                PieceType.U => new U(board),
                _ => new Empty(board),
            };
        }
    }
}
