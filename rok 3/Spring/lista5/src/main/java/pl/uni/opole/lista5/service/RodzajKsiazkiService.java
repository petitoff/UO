package pl.uni.opole.lista5.service;

import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import pl.uni.opole.lista5.model.Autor;
import pl.uni.opole.lista5.model.RodzajKsiazki;
import pl.uni.opole.lista5.repo.RodzajKsiazkiRepo;

import java.util.List;

@Service
public class RodzajKsiazkiService {
    @Autowired
    private RodzajKsiazkiRepo repo;

    public List<RodzajKsiazki> getAllRodzajKsiazki()
    {
        return repo.findAll();
    }

    public RodzajKsiazki addRodzajKsiazki(RodzajKsiazki newRodzajKsiazki)
    {
        RodzajKsiazki savedRodzajKsiazki = repo.save(newRodzajKsiazki);
        return savedRodzajKsiazki;
    }

    public RodzajKsiazki editRodzajKsiazki(Integer id,RodzajKsiazki rodzaj)
    {
        RodzajKsiazki editedRodzajKsiazki = repo.findById(id).get();

        editedRodzajKsiazki.setNazwa(rodzaj.getNazwa());
        editedRodzajKsiazki.setSymbol(rodzaj.getSymbol());
        editedRodzajKsiazki.setKsiazki(rodzaj.getKsiazki());
        return repo.save(editedRodzajKsiazki);
    }

    public Boolean deletedRodzajKsiazki(Integer id)
    {
        repo.deleteById(id);

        try
        {
            if (repo.getById(id) != null)
                return false;
            else
                return true;
        }
        catch(EntityNotFoundException e)
        {
            return true;
        }
    }
}
