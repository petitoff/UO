package pl.opole.uni.lista1.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@DiscriminatorValue("spodnica")
@Table(name="spodnica")
public class Spodnica extends Ubranie{
    private String rodzaj;
    private Boolean czy_dluga;

    public String getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(String rodzaj) {
        this.rodzaj = rodzaj;
    }

    public Boolean isCzy_dluga() {
        return czy_dluga;
    }

    public void setCzy_dluga(Boolean czy_dluga) {
        this.czy_dluga = czy_dluga;
    }
}
