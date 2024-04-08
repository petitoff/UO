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
    @GetMapping("/MarcinNowak")
    public List<Uzytkownik> getMarcinNowak(){return repo.findByImieEqualsAndNazwiskoEquals("Marcin","Nowak");}
    @GetMapping("/NazwiskoKN")
    public List<Uzytkownik> getNazwiskoKN(){return repo.findByNazwiskoLikeOrNazwiskoLike("K%","N%");}

}
