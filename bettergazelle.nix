{ buildDotnetModule, fetchFromGitHub }:

buildDotnetModule rec {
  pname   = "bettergazelle";
  version = "1.0.0";
  meta    = {
  	description = "Collection of (quickly thrown-together) tools to make you a better gazelle.";
  	homepage    = "https://github.com/Hayajiro/bettergazelle";
  };

  src = fetchFromGitHub {
    owner  = "Hayajiro";
    repo   = "bettergazelle";
    rev    = "cfaccd17fbcaf159b7845ebc8b630db9e6e3e223";
    sha256 = "sha256-jwUTJi42bRZsRrXxa7n4uI0mnVX5vAZJMagxkUrCyko=";
  };

  nugetDeps = builtins.toFile "deps.nix" "{ fetchNuGet }: []";
}