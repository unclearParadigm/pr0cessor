using System;

namespace Pr0cessor.Models.Pr0grammApi {
  [Flags]
  public enum Flags {
    SFW = 1,
    NSFW = 2,
    NSFL = 4,
    NSFP = 8,
    AllPublic = SFW | NSFW | NSFL,
    All = AllPublic | NSFP
  }
}
