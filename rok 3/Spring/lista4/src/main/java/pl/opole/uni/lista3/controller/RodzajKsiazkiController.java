package pl.opole.uni.lista3.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import pl.opole.uni.lista3.model.RodzajKsiazki;
import pl.opole.uni.lista3.service.RodzajKsiazkiService;

import java.util.List;

@RestController
public class RodzajKsiazkiController {
    @Autowired
    private RodzajKsiazkiService service;

    @GetMapping("/selectRodzajKsiazki")
    public List<RodzajKsiazki> getRodzajeKsiazki(String name)
    {
        return service.getAllRodzajKsiazki();
    }

    @PostMapping("/insertRodzajKsiazki")
    public RodzajKsiazki addRodzajKsiazki(@RequestBody RodzajKsiazki newRodzajKsiazki)
    {
        return service.addRodzajKsiazki(newRodzajKsiazki);
    }

    @PutMapping("/updateRodzajKsiazki")
    public RodzajKsiazki editRodzajKsiazki(@RequestParam(required = true) Integer id, @RequestBody RodzajKsiazki newRodzajKsiazki)
    {
        return service.editRodzajKsiazki(id,newRodzajKsiazki);
    }

    @DeleteMapping("/deleteRodzajKsiazki")
    public Boolean deletedRodzajKsiazki(@RequestParam(required = true) Integer id)
    {
        return service.deletedRodzajKsiazki(id);
    }
}
