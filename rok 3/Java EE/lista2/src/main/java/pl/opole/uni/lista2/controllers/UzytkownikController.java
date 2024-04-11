package pl.opole.uni.lista2.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.opole.uni.lista2.model.Uzytkownik;
import pl.opole.uni.lista2.repo.UrzadzenieRepo;
import pl.opole.uni.lista2.repo.UzytkownikRepo;

import java.util.List;

@RestController
public class UzytkownikController {
    @Autowired
    private UzytkownikRepo repo;
    @GetMapping("/MarcinNowakJPQL")
    public List<Uzytkownik> getMarcinNowakJPQL(){return repo.findMarcinNowakJPQL();}
    @GetMapping("/MarcinNowakSQL")
    public List<Uzytkownik> getMarcinNowakSQL(){return repo.findMarcinNowakSQL();}
    @GetMapping("/NazwiskoKNJPQL")
    public List<Uzytkownik> getNazwiskoKNJPQL(){return repo.findNazwiskoKNJPQL();}
    @GetMapping("/NazwiskoKNSQL")
    public List<Uzytkownik> getNazwiskoKNSQL(){return repo.findNazwiskoKNSQL();}
}
