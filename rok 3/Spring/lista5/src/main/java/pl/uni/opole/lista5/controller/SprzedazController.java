package pl.uni.opole.lista5.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import pl.uni.opole.lista5.model.Sprzedaz;
import pl.uni.opole.lista5.service.SprzedazService;

import java.util.List;

@RestController
public class SprzedazController {
    @Autowired
    private SprzedazService service;

    @GetMapping("/selectSprzedaz")
    public List<Sprzedaz> getSprzedaz()
    {
        return service.getAllSprzedarz();
    }

    @PostMapping("/insertSprzedaz")
    public Sprzedaz addSprzedaz(@RequestBody Sprzedaz newSprzedaz)
    {
        return service.addSprzedaz(newSprzedaz);
    }

    @PutMapping("/updateSprzedaz")
    public Sprzedaz updateSprzedaz(@RequestParam(required = true) Integer id,@RequestBody Sprzedaz newSprzedaz)
    {
        return service.editSprzedaz(id,newSprzedaz);
    }

    @DeleteMapping("/deleteSprzedaz")
    public Boolean deleteSprzedaz(@RequestParam(required = true)Integer id)
    {
        return service.deletedSprzedaz(id);
    }
}
