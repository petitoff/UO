package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@Table(name="ptak")
public class Ptak extends Zwierze{
    private String opierzenie;
    private Boolean czy_lata;

    public String getOpierzenie() {
        return opierzenie;
    }

    public void setOpierzenie(String opierzenie) {
        this.opierzenie = opierzenie;
    }

    public Boolean getCzy_lata() {
        return czy_lata;
    }

    public void setCzy_lata(Boolean czy_lata) {
        this.czy_lata = czy_lata;
    }
}
