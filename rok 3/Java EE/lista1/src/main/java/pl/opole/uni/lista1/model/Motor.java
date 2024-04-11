package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@Table(name="motor")
public class Motor extends Pojazd{
    private Boolean czy_pojemnik;
    private Boolean czy_jednoosobowy;

    public Boolean getCzy_pojemnik() {
        return czy_pojemnik;
    }

    public void setCzy_pojemnik(Boolean czy_pojemnik) {
        this.czy_pojemnik = czy_pojemnik;
    }

    public Boolean getCzy_jednoosobowy() {
        return czy_jednoosobowy;
    }

    public void setCzy_jednoosobowy(Boolean czy_jednoosobowy) {
        this.czy_jednoosobowy = czy_jednoosobowy;
    }
}
