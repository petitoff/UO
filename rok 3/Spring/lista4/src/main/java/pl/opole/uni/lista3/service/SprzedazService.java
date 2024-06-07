package pl.opole.uni.lista3.service;

import jakarta.persistence.EntityNotFoundException;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import pl.opole.uni.lista3.model.Ksiazka;
import pl.opole.uni.lista3.model.Sprzedaz;
import pl.opole.uni.lista3.repo.KsiazkaRepo;
import pl.opole.uni.lista3.repo.SprzedazRepo;

import java.util.List;

@Service
public class SprzedazService {
    @Autowired
    private SprzedazRepo repo;
    @Autowired
    private KsiazkaRepo ksiazkaRepo;

    public List<Sprzedaz> getAllSprzedarz()
    {
        return repo.findAll();
    }

    @Transactional
    public Sprzedaz addSprzedaz(Sprzedaz newSprzedaz)
    {
        Ksiazka ksiazka = ksiazkaRepo.findById(newSprzedaz.getKsiazka().getKsiazkaID()).get();
        ksiazka.setStan(ksiazka.getStan()-newSprzedaz.getIlosc());
        Sprzedaz sprzedaz = newSprzedaz;
        sprzedaz.setKsiazka(ksiazka);
        sprzedaz.setCena(ksiazka.getCena()*newSprzedaz.getIlosc());

        repo.save(sprzedaz);
        ksiazkaRepo.save(ksiazka);
        return sprzedaz;
    }

    @Transactional
    public Sprzedaz editSprzedaz(Integer id, Sprzedaz sprzedaz)
    {
        Sprzedaz editedSprzedaz = repo.findById(id).get();
        if(sprzedaz.getKsiazka().getKsiazkaID().equals(editedSprzedaz.getKsiazka().getKsiazkaID()))
        {
            Ksiazka ksiazka = ksiazkaRepo.findById(editedSprzedaz.getKsiazka().getKsiazkaID()).get();
            ksiazka.setStan(ksiazka.getStan() - (sprzedaz.getIlosc() - editedSprzedaz.getIlosc()));
            editedSprzedaz.setCena(ksiazka.getCena() * sprzedaz.getIlosc());
            editedSprzedaz.setDate(sprzedaz.getDate());
            editedSprzedaz.setIlosc(sprzedaz.getIlosc());
            editedSprzedaz.setKsiazka(ksiazka);
            ksiazkaRepo.save(ksiazka);
            return repo.save(editedSprzedaz);
        }
        else
        {
            Ksiazka ksiazkabefore = ksiazkaRepo.findById(editedSprzedaz.getKsiazka().getKsiazkaID()).get();
            Ksiazka ksiazkaafter = ksiazkaRepo.findById(sprzedaz.getKsiazka().getKsiazkaID()).get();
            ksiazkabefore.setStan(ksiazkabefore.getStan() + editedSprzedaz.getIlosc());
            ksiazkaafter.setStan(ksiazkaafter.getStan() - sprzedaz.getIlosc());
            editedSprzedaz.setCena(ksiazkaafter.getCena() * sprzedaz.getIlosc());
            editedSprzedaz.setDate(sprzedaz.getDate());
            editedSprzedaz.setIlosc(sprzedaz.getIlosc());
            editedSprzedaz.setKsiazka(ksiazkaafter);
            ksiazkaRepo.save(ksiazkabefore);
            ksiazkaRepo.save(ksiazkaafter);
            return repo.save(editedSprzedaz);
        }
    }

    @Transactional
    public Boolean deletedSprzedaz(Integer id)
    {
        Sprzedaz sprzedaz = repo.findById(id).get();
        Ksiazka ksiazka = ksiazkaRepo.findById(sprzedaz.getKsiazka().getKsiazkaID()).get();
        ksiazka.setStan(ksiazka.getStan()+sprzedaz.getIlosc());
        repo.deleteById(id);

        try
        {
            if(repo.findById(id) == null)
                return true;
            else
                return false;
        }
        catch(EntityNotFoundException e)
        {
            return false;
        }
    }
}
