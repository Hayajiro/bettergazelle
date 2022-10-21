{ config, lib, pkgs, ... }:

with lib;
let
  cfg        = config.services.freeleecher;
  configFile = pkgs.writeText "ggn.tokens" ''
    ${cfg.apiToken}
    ${cfg.authToken}
    ${cfg.torrentPass}
  '';
in {
  options.services.freeleecher = {
    enable = mkEnableOption (mdDoc "the bettergazelle freeleecher client");

    watchFolder = mkOption {
      type        = types.path;
      description = mdDoc "Path to watch folder where torrent file will be written.";
    };

    apiToken = mkOption {
      type        = types.str;
      description = mdDoc "GGn API token with the \"Torrents\" and \"Site Info\" scopes";
    };

    authToken = mkOption {
      type        = types.str;
      description = mdDoc "The value of the \"authkey\" parameter found in a torrent download URL";
    };

    torrentPass = mkOption {
      type        = types.str;
      description = mdDoc "The value of the \"torrent_pass\" parameter found in a torrent download URL";
    };
  };

  config = mkIf cfg.enable {  
    systemd.services.freeleecher = {
  	  description   = "bettergazelle freeleecher client";
  	  after         = [ "network-online.target" ];
  	  wantedBy      = [ "multi-user.target" ];
      serviceConfig = {
        Type      = "exec";
        ExecStart = "${pkgs.bettergazelle}/bin/bettergazelle.freeleecher ${cfg.watchFolder} ${configFile}";
      };
  	};
  };
}